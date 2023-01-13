using Photon.Pun;
using UnityEngine;
public class playerController : MonoBehaviourPunCallbacks
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float speedIncrement;
    [SerializeField] float speedDecrement;
    [SerializeField] float rotationSpeed;
    public bool canWork;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        int gravity = PlayerPrefs.GetInt("setting");
        
        rb = GetComponent<Rigidbody>();
        if (gravity == 1)
        {
            rb.useGravity = true;
        }
      
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
       
        
        if (photonView.IsMine)
        {
            rb.velocity = transform.up * speed;
            if (Input.GetKey(KeyCode.W))
            {
                if (speed < maxSpeed)
                {
                    speed *= speedIncrement;
                }

            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (speed > minSpeed)
                {
                    speed *= speedDecrement;
                }

            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-Vector3.forward, rotationSpeed * Time.deltaTime, Space.World);
            }

        }



        
     
    }
}
