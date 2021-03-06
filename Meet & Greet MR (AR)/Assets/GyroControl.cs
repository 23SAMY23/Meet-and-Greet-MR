using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    public GameObject cameraContainer;
  //  public Transform head;
    private Quaternion rot;

    private void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

              cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
               rot = new Quaternion(0, 0, 1, 0);
            //cameraContainer.transform.Rotate(0,-Input.gyro.rotationRateUnbiased.y,0);
           // this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x,0,0);

            return true;
        }
        return false;
    }
    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
    }
}  
    

