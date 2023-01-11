using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float verticalInput;
    //forward

    public float turnSpeed;
    public float horizontalInput;
    //turning

    public float jumpForce;
    public KeyCode jumpKey;
    private Rigidbody rb;
    private bool isOnGround = true;
    //jump


    public KeyCode attackKey;
    //attack
    public KeyCode crouchKey;
    public bool isCrouching = false;
    //crouch



    public Animator Animator; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //move forward and back
        
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
        
       
        //turn
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        //jump
        if(Input.GetKeyDown(jumpKey) && isOnGround )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            
        }


        

        if (Input.GetKey(crouchKey))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
        Animator.SetBool("isCrouching", isCrouching);

        
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Animator.SetBool("isOnGround", isOnGround);
        }

    }
    
}
