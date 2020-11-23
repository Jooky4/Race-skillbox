using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Controller : MonoBehaviour
{

    public AxleInfo[] carAxis = new AxleInfo[2];//количество осей автомобиля
    public float carSpeed; //скорость машины можно отредактировать в Inspector
    public float steerAngle; //  угол поворота колёс можно отредактировать в Inspector

    private float horInput;
    float vertInput;
    void FixedUpdate()
    {
        horInput = Input.GetAxis("Horizontal_2");//считываем пользовательские нажатия с клавиш управления машиной. Заранее нужно поменять в InputManager название вторых полей Horizontal и Vertical
        vertInput = Input.GetAxis("Vertical_2");//на Horizontal_2 и Vertical_2

        Accelerate();
    }
    /// <summary>
    /// Метод, реализующий руление и передачу крутящего момента на ось
    /// </summary>
    void Accelerate()
    {
        foreach (AxleInfo axle in carAxis)
        {
            if (axle.steering)
            {
                axle.rightWheel.steerAngle = steerAngle * horInput;//передаём наклон на правое  колесо оси по нажатию на клавишу
                axle.leftWheel.steerAngle = steerAngle * horInput;//передаём наклон на левое  колеса оси по нажатию на клавишу
            }
            if (axle.motor)
            {
                axle.rightWheel.motorTorque = carSpeed * vertInput;//передаём крутящий момент на правое колесо
                axle.leftWheel.motorTorque = carSpeed * vertInput;//передаём крутящий момент на левое колесо
            }
            VisualWheelToCollider(axle.rightWheel, axle.visRightWheel);//связываем модель колеса с её wheelCollider
            VisualWheelToCollider(axle.leftWheel, axle.visLeftWheel);//связываем модель колеса с её wheelCollider
        }
    }
    /// <summary>
    /// Метод связывания 3d-модели колеса с её wheelCollider
    /// </summary>
    /// <param name="col"></param>
    /// <param name="visWheel"></param>
    void VisualWheelToCollider(WheelCollider col, Transform visWheel)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);
        visWheel.position = position;
    }
    /// <summary>
    /// Класс, описывающий одну ось автомобиля
    /// </summary>
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider rightWheel;//коллайдеры правого и левого колёс на оси
        public WheelCollider leftWheel;

        public Transform visRightWheel;//модели правого и левого колёс
        public Transform visLeftWheel;

        public bool steering;//включение/отключение руления на оси
        public bool motor;//включение/отключение крутящего момента на оси 
    }
}
