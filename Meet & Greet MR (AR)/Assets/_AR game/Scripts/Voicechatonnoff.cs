using Photon.Voice.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voicechatonnoff : MonoBehaviour
{
    /*This script is to turn voice chat on or off through ui button in AR*/
    public GameObject Photonvoicechat;
    public bool voice;
    public Sprite voiceoff;
    public Sprite voiceon;
    // Start is called before the first frame update

    void Start()
    {
       // Photonvoicechat = GameObject.FindGameObjectWithTag("Voice");   
    }
    void Update()
    {
        if (voice == true)
        {
            Photonvoicechat.gameObject.GetComponent<AudioSource>().enabled = true;
        }else
        {
            Photonvoicechat.gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }

    // Update is called once per frame
    public void voiceonnoff()
    {
        if (voice == true){
            this.GetComponent<Image>().sprite = voiceoff;
            voice = false;
        } else
        {
            this.GetComponent<Image>().sprite = voiceon;
            voice = true;
        }
    }
}
