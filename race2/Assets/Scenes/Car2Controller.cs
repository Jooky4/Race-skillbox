using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Controller : MonoBehaviour {

    public AxleInfo[] carAxis = new AxleInfo[2];
    public float carSpeed;
    public float steerAngle;

    private float horInput;
    float vertInput;
    void FixedUpdate()
    {
        horInput = Input.GetAxis("Horizontal_2");
        vertInput = Input.GetAxis("Vertical_2");

        Accelerate();
    }
    void Accelerate()
    {
        foreach (AxleInfo axle in carAxis)
        {
            if (axle.steering)
            {
                axle.rightWheel.steerAngle = steerAngle * horInput;
                axle.leftWheel.steerAngle = steerAngle * horInput;
            }
            if (axle.motor)
            {
                axle.rightWheel.motorTorque = carSpeed * vertInput;
                axle.leftWheel.motorTorque = carSpeed * vertInput;
            }
            VisualWheelToCollider(axle.rightWheel, axle.visRightWheel);
            VisualWheelToCollider(axle.leftWheel, axle.visLeftWheel);
        } 
    }
    void VisualWheelToCollider(WheelCollider col, Transform visWheel)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);
        visWheel.position = position;
        visWheel.rotation = rotation; 
    }
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider rightWheel;
        public WheelCollider leftWheel;

        public Transform visRightWheel;
        public Transform visLeftWheel;

        public bool steering;
        public bool motor;
    }
}
