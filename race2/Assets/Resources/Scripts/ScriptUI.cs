using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScriptUI : MonoBehaviour
{
    // public Text timerText = 3; //Текст таймера до старта гонок
    
    public void OnCklickStartGame() // Запуск игры
    {
        SceneManager.LoadScene("map1", LoadSceneMode.Additive);
        //Application.LoadLevel(name: "map1"); // Запуск игровой сцены
    }

    public void OnCklickExitGame() // Выход из игры при нажатии кнопки в меню
    {
        Application.Quit();  // Закрыть приложение
    }

   /* public void TimerStart()
    {

    }*/
    void Update() // Завершает работу приложения при нажатии на кнопку Esc
    {
        if (Input.GetKey("escape")) // если нажата кнопка Esc (Escape)
        {
            Application.Quit();  // Закрыть приложение
        }
    }
}