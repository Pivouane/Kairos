using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour
{
    private string _gameversion = "0.1";
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(_gameversion);
    }
    void Update()
    {
        Debug.Log(PhotonNetwork.connectionStateDetailed);
        
    }



}
