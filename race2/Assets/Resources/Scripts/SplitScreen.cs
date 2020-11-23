using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public Camera CamRed;           // Для подключения камеры красного игрока 
    public Camera CamBlue;          // Для подключения камеры синего игрока 

    public bool Horizontal = true; // Для отображения экранов по горизонтали

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // если нажата клавиша "Space"
        {
            ChangeScreen(); 
        }
    }

    public void ChangeScreen() // Метод смены режима отображения экранов
    {
        Horizontal = !Horizontal;

        if (Horizontal) // Если экраны горизонтальны
        {
            CamRed.rect = new Rect(0, 0, 1, 0.5f);
            CamBlue.rect = new Rect(0, 0.5f, 1, 0.5f);
        }
        else
        {
            CamRed.rect = new Rect(0, 0, 0.5f, 1);
            CamBlue.rect = new Rect(0.5f, 0, 0.5f, 1);
        }
    }
}
