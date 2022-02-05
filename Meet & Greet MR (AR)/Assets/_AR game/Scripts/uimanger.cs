using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uimanger : MonoBehaviour
{
    /*This script is to show joystick or home button when you call this function */

    public GameObject MOVEJOYSTICK;

    public bool move;

    public GameObject Home;
    public bool Homee;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movee()
    {
        if(move == true)
        {
            MOVEJOYSTICK.gameObject.SetActive(true);
            move = false;
        }
        else if( move == false)
        {
            MOVEJOYSTICK.gameObject.SetActive(false);
            move = true;
        }
    }

    public void hom()
    {
        if (Homee == true)
        {
            Home.gameObject.SetActive(true);
            Homee = false;
        }
        else if (Homee == false)
        {
            Home.gameObject.SetActive(false);
            Homee = true;
        }
    }


}
