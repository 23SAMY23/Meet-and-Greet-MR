using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Subsystems;

public class AvatarInputConverter : MonoBehaviour
{

    //Avatar Transforms
    public Transform MainAvatarTransform;
    public Transform AvatarHead;
    public Transform AvatarBody;

    public Transform AvatarHand_Left;
    public Transform AvatarHand_Right;

    //XRRig Transforms
    public Transform XRHead;

   // public Transform XRHand_Left;
  //  public Transform XRHand_Right;

    public Vector3 headPositionOffset;
    public Vector3 handRotationOffset;
    public bool game;
    public GameObject ARSession;
    public GameObject AROrigin;
    void Start()
    {
        /*       XRHead.gameObject.SetActive(true);

               ARSession.gameObject.GetComponent<ARSessionOrigin>().enabled = false;



               XRHead.gameObject.GetComponent<ARCameraManager>().requestedFacingDirection = CameraFacingDirection.World;
              


               ARSession.gameObject.GetComponent<ARSessionOrigin>().enabled = true;*/
               if(game == true)
        {
            StartCoroutine(coroutineA());
        }
        
    }
 

    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(1.0f);
        ARSession.gameObject.SetActive(true);
        AROrigin.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        //Head and Body synch
        // MainAvatarTransform.position = Vector3.Lerp(MainAvatarTransform.position, XRHead.position + headPositionOffset, 0.5f);
        XRHead.position =new Vector3(AvatarHead.position.x,AvatarHead.position.y + 0.2f,AvatarHead.position.z + 0.1f);
        AvatarHead.rotation = Quaternion.Lerp(AvatarHead.rotation, XRHead.rotation, 0.5f);
        AvatarBody.rotation = Quaternion.Lerp(AvatarBody.rotation, Quaternion.Euler(new Vector3(0, AvatarHead.rotation.eulerAngles.y, 0)), 0.05f);

        //Hands synch
     //  AvatarHand_Right.position = Vector3.Lerp(AvatarHand_Right.position,XRHand_Right.position,0.5f);
      // AvatarHand_Right.rotation = Quaternion.Lerp(AvatarHand_Right.rotation, Quaternion.Euler(new Vector3(0, AvatarHead.rotation.eulerAngles.y, 0)), 0.05f);

        //    AvatarHand_Left.position = Vector3.Lerp(AvatarHand_Left.position,XRHand_Left.position,0.5f);
        //    AvatarHand_Left.rotation = Quaternion.Lerp(AvatarHand_Left.rotation, Quaternion.Euler(new Vector3(0, AvatarHead.rotation.eulerAngles.y, 0)), 0.05f);
    }
}
