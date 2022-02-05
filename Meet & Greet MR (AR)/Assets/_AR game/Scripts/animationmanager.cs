using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationmanager : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public Animation l;
    public Animation r;
    /*This script is to make player do wave animation in the game*/

    public void WaVE()
    {
       l.Play("wave");
        r.Play("wave 1");
    }
}
