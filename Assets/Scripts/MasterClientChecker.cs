using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterClientChecker : Photon.PunBehaviour
{

    public Text textField;
    public string UserID;

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.playerName = UserID;
        PhotonNetwork.ConnectUsingSettings("Test");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Master checker", new RoomOptions(), new TypedLobby());
    }

    public override void OnJoinedRoom()
    {
        textField.text = PhotonNetwork.isMasterClient ? "I am a master!" : "Not a master =(";
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer other)
    {
        textField.text += "\nOnPhotonPlayerConnected() " + other.NickName;
        Debug.Log("OnPhotonPlayerConnected() " + other.NickName); // not seen if you're the player connecting

        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected


            //LoadArena();
        }
    }

    public override void OnLeftRoom()
    {

    }

}
