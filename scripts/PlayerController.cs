using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float verticalInput;
    public bool movingForward = true;
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
    public bool isDead = false;
    public GameObject deathscreen; //deathscreeen
    public AudioSource DeathSound; //deathsound
    //death


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
        
        
        
       
        //turn
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        //jump
        if(Input.GetKeyDown(jumpKey) && isOnGround )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Animator.SetBool("isOnGround", isOnGround);

            
        }


        //crouch

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
        if (collision.gameObject.CompareTag("obstacle"))
        {
            isDead = true;
            deathscreen.SetActive(true);
            Animator.SetBool("isDead", isDead);
            movingForward = false;

            DeathSound.Play();


        }

    }



}
