using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textchatonnoff : MonoBehaviour
{
    /*This Script is to play Animation on text chat box when its on or off*/
    public GameObject Scrollview;
    public bool Chat;
    public Sprite Chatoff; 
    public Sprite Chaton;
    // Start is called before the first frame update

    public void Chattextonoff()
    {
        
        if (Chat == true)
        {
            Scrollview.GetComponent<Animation>().Play("Scrollviewon");
            this.GetComponent<Image>().sprite = Chatoff;
            Chat = false;
        }
        else
        {
            Scrollview.GetComponent<Animation>().Play("Scrollviewoff");
            this.GetComponent<Image>().sprite = Chaton;
            Chat = true;
        }
    }
}
