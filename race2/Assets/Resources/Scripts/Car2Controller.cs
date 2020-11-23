using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Controller : MonoBehaviour
{

    public AxleInfo[] carAxis = new AxleInfo[2];//���������� ���� ����������
    public float carSpeed; //�������� ������ ����� ��������������� � Inspector
    public float steerAngle; //  ���� �������� ���� ����� ��������������� � Inspector

    private float horInput;
    float vertInput;
    void FixedUpdate()
    {
        horInput = Input.GetAxis("Horizontal_2");//��������� ���������������� ������� � ������ ���������� �������. ������� ����� �������� � InputManager �������� ������ ����� Horizontal � Vertical
        vertInput = Input.GetAxis("Vertical_2");//�� Horizontal_2 � Vertical_2

        Accelerate();
    }
    /// <summary>
    /// �����, ����������� ������� � �������� ��������� ������� �� ���
    /// </summary>
    void Accelerate()
    {
        foreach (AxleInfo axle in carAxis)
        {
            if (axle.steering)
            {
                axle.rightWheel.steerAngle = steerAngle * horInput;//������� ������ �� ������  ������ ��� �� ������� �� �������
                axle.leftWheel.steerAngle = steerAngle * horInput;//������� ������ �� �����  ������ ��� �� ������� �� �������
            }
            if (axle.motor)
            {
                axle.rightWheel.motorTorque = carSpeed * vertInput;//������� �������� ������ �� ������ ������
                axle.leftWheel.motorTorque = carSpeed * vertInput;//������� �������� ������ �� ����� ������
            }
            VisualWheelToCollider(axle.rightWheel, axle.visRightWheel);//��������� ������ ������ � � wheelCollider
            VisualWheelToCollider(axle.leftWheel, axle.visLeftWheel);//��������� ������ ������ � � wheelCollider
        }
    }
    /// <summary>
    /// ����� ���������� 3d-������ ������ � � wheelCollider
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
    /// �����, ����������� ���� ��� ����������
    /// </summary>
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider rightWheel;//���������� ������� � ������ ���� �� ���
        public WheelCollider leftWheel;

        public Transform visRightWheel;//������ ������� � ������ ����
        public Transform visLeftWheel;

        public bool steering;//���������/���������� ������� �� ���
        public bool motor;//���������/���������� ��������� ������� �� ��� 
    }
}
