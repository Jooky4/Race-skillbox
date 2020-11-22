using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Vector3 = System.Numerics.Vector3;
using System;

public class GameManager : MonoBehaviour
{
    #region AllVariables >>
    
    [SerializeField] private Text textCircleRed;        // Для вывода текста на экран очков красного игрока
    [SerializeField] private Text textCircleBlue;       // Для вывода текста на экран очков синего игрока
    [SerializeField] private Text textTimer;            // Для вывода текста таймера

    [SerializeField] private GameObject carPrefabRed;   // Для подключения к префабу машины красного игрока
    [SerializeField] private GameObject carPrefabBlue;  // Для подключения к префабу машины синего игрока

    [SerializeField] private Collider colliderFinish;   // Для подключения к финишной линии

    [SerializeField] private Transform spawnPosRed;     // Для подключения к точке спавна красного игрока
    [SerializeField] private Transform spawnPosBlue;    // Для подключения к точке спавна синего игрока

    [SerializeField] public Text textEndGame;           // Для вывода текста на экран в конце игры

    [SerializeField] private float timerGame = 5.0f;    // Для таймера
    private bool isGame = false;                        // Зависит от таймера
    
    #endregion

    //------------- Update -----------------------------------------------------
    protected void Update()
        {
            if (isGame == false)
            {
                timerGame -= Time.deltaTime;                       // Отсчёт таймера
                CarsStart();
            }

        textCircleRed.text = WinVar.circlePlayerRed.ToString();   // Вывод очков на экран красного игрока
        textCircleBlue.text = WinVar.circlePlayerBlue.ToString(); // Вывод очков на экран синего игрока
        textTimer.text = timerGame.ToString("#");     // Вывод таймера на экран
        
        //------------------- Update: возвращает на экран меню при нажатии на кнопку Esc -----------------
        if (Input.GetKey("escape")) // Если нажата кнопка Esc (Escape)
        {
            WinVar.circlePlayerBlue = 0;                        // Обнуление прогресса игроков
            WinVar.circlePlayerRed = 0;
            SceneManager.LoadScene("MainScene");       // Возвращает на экран меню
        }

    }

    //--------------- CarsStart: метод блокировки старта игры ---------------------------------------------
    private void CarsStart()
    {
        if (timerGame <= 0)                              // Если отсчёт таймера закончился
        {
            isGame = true;
            textTimer.gameObject.SetActive(false); // Отключение текста таймера
            StartSpawnCars();
        }
        else if (timerGame > 0)                         // Если отсчёт таймера не закончился
        {
            isGame = false;
            textTimer.gameObject.SetActive(true); // включение текста таймера
        }
    }

    //-------------- StartSpawnCars: метод появление машин в точках спавна -----------------------------
    public void StartSpawnCars() 
    {
        
        Instantiate(carPrefabRed, spawnPosRed.position, Quaternion.identity);   // Спавн красной машины
        Instantiate(carPrefabBlue, spawnPosBlue.position, Quaternion.identity); // Спавн синей машины 
        //GameObject.Find("MainCamera").SetActive(false);

        // спавн синей машины и её разворот на 180 градусов
      /*  Instantiate(carPrefabBlue, spawnPosBlue.position, 
            Quaternion.FromToRotation(UnityEngine.Vector3.left, UnityEngine.Vector3.right));*/
    }

    //-------------- EndGame: метод завершения игры ------------------------------------------------------
    public void EndGame()
    {
        if ((WinVar.circlePlayerRed <= WinVar.totalCircle) 
            && (WinVar.circlePlayerRed > WinVar.circlePlayerBlue) 
            && (SceneManager.GetActiveScene().name == "Level3"))           // Если красный игрок выполнил условия победы
        {
            textEndGame.gameObject.SetActive(true);                  // Включение текста и вывод текста
            textEndGame.text = $"Победил красный игрок!";
            Invoke("ReturnStart", 3f);          // Задержка на 3 секунды
        } 
        else if ((WinVar.circlePlayerBlue <= WinVar.totalCircle )
                 && (WinVar.circlePlayerBlue > WinVar.circlePlayerRed) 
                 && (SceneManager.GetActiveScene().name == "Level3"))     // Если синий игрок выполнил условия победы
        {
            textEndGame.gameObject.SetActive(true);                  // Включение текста и вывод текста
            textEndGame.text = $"Победил синий игрок!";
            Invoke("ReturnStart", 3f);          // Задержка на 3 секунды
        }
    }
    //--------------- ReturnStart: метод перехода в главное меню ---------------------------------------------
    private void ReturnStart()                     
    {
        WinVar.circlePlayerBlue = 0;                                  // Обнуление прогресса игроков
        WinVar.circlePlayerRed = 0;                                   
        SceneManager.LoadScene("MainScene");                  // Переход на сцену с меню
    }
}
