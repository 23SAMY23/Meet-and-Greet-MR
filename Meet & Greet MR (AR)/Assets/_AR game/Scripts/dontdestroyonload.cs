using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyonload : MonoBehaviour
{
    // this will not destroy on new scene load
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
