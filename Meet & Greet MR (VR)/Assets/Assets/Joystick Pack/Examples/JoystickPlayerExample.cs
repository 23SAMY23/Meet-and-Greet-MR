using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public VariableJoystick RotationJoystick;
    public CharacterController cc;
    public Vector3 impact = Vector3.zero;
    public GameObject mainavatar;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        direction *= speed;

        cc.Move (direction * Time.fixedDeltaTime);

        Vector3 target = Vector3.up * RotationJoystick.Horizontal;
        target *= speed * Time.fixedDeltaTime;
        mainavatar.transform.Rotate(target);
       // cc.transform.rotation(target * Time.fixedDeltaTime);
    }
}