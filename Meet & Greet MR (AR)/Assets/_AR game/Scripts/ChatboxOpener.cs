using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class ChatboxOpener : MonoBehaviour
{
/*This Script is for opening chatbox when player click left hand Y button in Oculus controller */

    [SerializeField]
    GameObject UIController;

    [SerializeField]
    GameObject BaseController;

    [SerializeField]
    InputActionReference inputActionReference_chatboxOpen;


    bool ischatbox = false;


    [SerializeField]
    GameObject Chatbox;

    [SerializeField]
    GameObject vrkeyboards;
    Vrkeyboardchatbox vrkeybard;

    /*Here it takes chatbox and vr keyboard as a object and open it when player hit Y button in oculus controller*/
    private void OnEnable()
    {

        inputActionReference_chatboxOpen.action.performed += Activatechatbox;
    }
    private void OnDisable()
    {
        inputActionReference_chatboxOpen.action.performed -= Activatechatbox;

    }

    private void Start()
    {
        //Deactivating UI Canvas Gameobject by default


        if (Chatbox != null)
        {
            Chatbox.SetActive(false);
           

        }
    }

    /// <summary>
    /// This method is called when the player presses UI Switcher Button which is the input action defined in Default Input Actions.
    /// When it is called, UI interaction mode is switched on and off according to the previous state of the UI Canvas.
    /// </summary>
    /// <param name="obj"></param>


    private void Activatechatbox(InputAction.CallbackContext obj)
    {
        if (!ischatbox)
        {
            ischatbox = true;

            //Activating UI Controller by enabling its XR Ray Interactor and XR Interactor Line Visual
            UIController.GetComponent<XRRayInteractor>().enabled = true;
            UIController.GetComponent<XRInteractorLineVisual>().enabled = true;

            //Deactivating Base Controller by disabling its XR Direct Interactor
            BaseController.GetComponent<XRDirectInteractor>().enabled = false;



            //Activating the UI Canvas Gameobject
            Chatbox.SetActive(true);
            vrkeyboards.gameObject.GetComponent<Vrkeyboardchatbox>().EnableVRKeyboard();
        }
        else
        {
            ischatbox = false;

            //Activating Base Controller by disabling its XR Direct Interactor
            BaseController.GetComponent<XRDirectInteractor>().enabled = true;

            //De-Activating the UI Canvas Gameobject
            Chatbox.SetActive(false);
            vrkeyboards.gameObject.GetComponent<Vrkeyboardchatbox>().DisableVRKeyboard();
        }

    }

}