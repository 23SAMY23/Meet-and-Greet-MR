using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnManager : MonoBehaviour
{
    /*This Script is for spawn Player in the game*/
    [SerializeField]
    GameObject GenericVRPlayerPrefab;

    public Vector3[] spawnPosition;
    public int i;

    private void Awake()
    {
        i = Random.Range(0, 3);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name,spawnPosition[i],Quaternion.identity);
        }
    }
}
