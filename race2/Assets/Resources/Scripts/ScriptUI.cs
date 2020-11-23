using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScriptUI : MonoBehaviour
{
    //-------------------- LoadScene: метод перехода между сценами ---------------------------------------------------
    public void LoadScene(string Level) 
    {
        SceneManager.LoadScene(Level);       // Запуск игровой сцены
    }

    //------------------- OnClickExitGame: выход из игры при нажатии кнопки в меню -----------------------------------
    public void OnClickExitGame() 
    {
        Application.Quit();                  // Закрыть приложение
    }
    
}