using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;
using System.Diagnostics;

namespace RockVR.Video.Demo
{

    public class VideoCaptureUI : MonoBehaviour
    {
        [SerializeField]
        GameObject UIController;

        [SerializeField]
        GameObject BaseController;

        [SerializeField]
        InputActionReference inputActionReference_VideoRecord;

        [SerializeField]
        public GameObject Icon;



        private void Awake()
        {
            Application.runInBackground = true;
            Icon.SetActive(false);
        }


        private void OnEnable()
        {

            inputActionReference_VideoRecord.action.performed += ActivateVideo;
        }
        private void OnDisable()
        {
            inputActionReference_VideoRecord.action.performed -=ActivateVideo;

        }




        /// <param name="obj"></param>

        private void ActivateVideo(InputAction.CallbackContext obj)
        {
            
            
               if (VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.NOT_START || VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.FINISH)
               {
                VideoCaptureCtrl.instance.StartCapture();
                Icon.SetActive(true);

            }
               else if (VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.STARTED)
               {
                   VideoCaptureCtrl.instance.StopCapture();
                Icon.SetActive(false);


               }
        }
       
        



    }
}

        

       
