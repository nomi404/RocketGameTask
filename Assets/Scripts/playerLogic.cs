using Photon.Pun;
using UnityEngine;

public class playerLogic : MonoBehaviourPunCallbacks

{

    
    [SerializeField] multiplayer multiPlayer;
   


    private void Start()
    {
       
        multiPlayer = GameObject.FindGameObjectWithTag("multiplayer").GetComponent<multiplayer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
      

        if(collision.gameObject.CompareTag("Ground"))
        {
            multiPlayer.CallCourtine();
            PhotonNetwork.Destroy(photonView.gameObject);
            
        }
        
    }

    private void OnBecameInvisible()
    {
        Destroy(photonView.gameObject);
    }


 



}
