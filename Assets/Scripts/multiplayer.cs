using Photon.Pun;
using System.Collections;
using UnityEngine;

public class multiplayer : MonoBehaviourPunCallbacks
{
    public GameObject rocket;
    [SerializeField] Vector3 spawnPosPlayer1;
    [SerializeField] Vector3 spawnPosPlayer2;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();   
    }

    public override void OnConnectedToMaster()
    {
       
        PhotonNetwork.JoinRandomOrCreateRoom(); 
    }

    public override void OnJoinedRoom()
    {
       
            Spawn();

    }



    void Spawn()
    {
        int actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        if (actorNumber == 1)
        {
            PhotonNetwork.Instantiate(rocket.name, spawnPosPlayer1, Quaternion.Euler(0, 0, -90));
            
        }
        if (actorNumber == 2)
        {

            PhotonNetwork.Instantiate(rocket.name, spawnPosPlayer2, Quaternion.Euler(0,0,90));
           
        }
    }
    public void CallCourtine()
    {
        StartCoroutine(Respawn());
    }

   public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        Spawn();
    }
   

}
