using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backgroundmusic : MonoBehaviour
{
    /*This script is to play background music only on loginscene and home scene others there should not be any volume*/
    public AudioSource bg;

    // Update is called once per frame
    //this function is taking active scene name in runtime and checking the scene name for volume update
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        // Debug.Log(scene.name);
        if (scene.name == "LoginScene" || scene.name == "HomeScene")
        {
            bg.volume = 0.5f;
        }
        else if (scene.name == "World_Outdoor" || scene.name == "World_School")
        {

            bg.volume = 0;
        }

    }
}
