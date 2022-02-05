using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationscript : MonoBehaviour
{
    /*this scrpt is foor movement of the player on joystick*/
    public float speed;
    public VariableJoystick variableJoystick;
    public VariableJoystick rOTAIONJoystick;
    public CharacterController cc;
    // Start is called before the first frame update
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        direction *= speed;

        cc.Move(direction * Time.fixedDeltaTime);
    }
}
