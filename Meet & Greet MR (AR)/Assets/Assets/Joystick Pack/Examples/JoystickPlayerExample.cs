using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 This script is for the Ar Character Movement as on joystick vertical player 
 move forward and backward and on horizontal player rotate
     */
public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float rotatespeed = 3; 
    public VariableJoystick variableJoystick;
    public CharacterController cc;
    public Vector3 impact = Vector3.zero;
    public GameObject mainavatar;
    //this funtion move and rotate player on fixed update
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical;
        direction *= speed;
        direction = this.transform.TransformDirection(direction);
        cc.Move (direction * Time.fixedDeltaTime);
         Vector3 target = Vector3.up * -variableJoystick.Horizontal;
        target *= rotatespeed * Time.fixedDeltaTime;
        mainavatar.transform.Rotate(target);
        cc.transform.Rotate(target);
    }
}