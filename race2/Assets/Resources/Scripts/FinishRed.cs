﻿using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FinishRed : MonoBehaviour
{
    [SerializeField] private GameObject scriptGameManager;                           // Ссылка на скрипт GameManager

    void OnTriggerEnter(Collider other)                                              // Проверка на прохождение финиша
    {
        if (other.gameObject.CompareTag("CarRed") || other.gameObject.CompareTag("CarBlue"))
        {
            GameObject.Find("ImageLine").GetComponent<Image>().enabled = true;
            GameObject.Find("Finish").GetComponent<BoxCollider>().enabled = false; // Отключение коллайдера
            GameObject.Find("Finish").GetComponent<MeshRenderer>().enabled = false; // Отключение рендера, так как удалять его нельзя из-за повешенного на него скрипта
        }

        //--------------------------------- Проверка для красного игрока -------------------------------
        if (other.gameObject.CompareTag("CarRed"))
        {
            WinVar.circlePlayerRed += 1; // Начисление очков красному игроку
            
            // Проверка условия победы и текущего уровня                             
            if ((WinVar.circlePlayerRed < WinVar.totalCircle)         
                && (SceneManager.GetActiveScene().name == "Level_1"))
            {
                scriptGameManager.GetComponent<GameManager>().textEndGame.gameObject.SetActive(true);
                scriptGameManager.GetComponent<GameManager>().textEndGame.text = $"Красный быстрее!";
                Invoke("NextLevel2", 3f);
            }
            // Проверка условия победы и текущего уровня
            if ((WinVar.circlePlayerRed < WinVar.totalCircle) 
                && (SceneManager.GetActiveScene().name == "Level_2"))
            {
                scriptGameManager.GetComponent<GameManager>().textEndGame.gameObject.SetActive(true);
                scriptGameManager.GetComponent<GameManager>().textEndGame.text = $"Красный быстрее!";
                Invoke("NextLevel3", 3f);
            }
            // Если набрано необходимое количество очков, то конец игры
            else scriptGameManager.GetComponent<GameManager>().EndGame();
        }

        //--------------------------------- Проверка для синего игрока -------------------------------
        else if (other.gameObject.CompareTag("CarBlue"))
        {
            WinVar.circlePlayerBlue += 1; // Начисление очков синему игроку
            
            // Проверка условия победы и текущего уровня
            if ((WinVar.circlePlayerBlue < WinVar.totalCircle) 
                && (SceneManager.GetActiveScene().name == "Level_1"))
            {
                scriptGameManager.GetComponent<GameManager>().textEndGame.gameObject.SetActive(true);
                scriptGameManager.GetComponent<GameManager>().textEndGame.text = $"Синий быстрее!";
                Invoke("NextLevel2", 3f);
            }
            // Проверка условия победы и текущего уровня
            if ((WinVar.circlePlayerBlue < WinVar.totalCircle) 
                && (SceneManager.GetActiveScene().name == "Level_2"))
            {
                scriptGameManager.GetComponent<GameManager>().textEndGame.gameObject.SetActive(true);
                scriptGameManager.GetComponent<GameManager>().textEndGame.text = $"Синий быстрее!";
                Invoke("NextLevel3", 3f);
            }
            // Если набрано необходимое количество очков, то конец игры
            else scriptGameManager.GetComponent<GameManager>().EndGame();

        }
  
        
    }
    public void NextLevel2()                     // Переход на следующий уровень
    {
        SceneManager.LoadScene("Level_2"); // Запуск игровой сцены 
    }

    public void NextLevel3()                     // Переход на следующий уровень
    {
        SceneManager.LoadScene("Level_3"); // Запуск игровой сцены 
    }

}