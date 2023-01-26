using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioClip jumpsound;
    public AudioSource playerAudio;
    //audio

    public KeyCode attackKey;
    //attack
    public KeyCode crouchKey;
    public bool isCrouching = false;
    //crouch
    public bool isDead = false;
    public GameObject deathscreen; //deathscreeen
    public AudioSource DeathSound; //deathsound
    //death

    private GameManager Gamemanager;
   [SerializeField] private HighScoreManager highScoreManager;
    //game manager
    public Animator Animator; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (SceneManager.GetActiveScene().name == "TitleScreen")
        {
            highScoreManager = GameObject.Find("HighScoreManager").GetComponent<HighScoreManager>();
        }
        
        Animator = GetComponent<Animator>();
        
       // playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        //highscore

        
       
        //respawn
        if (isDead == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))                 
            {
                Gamemanager.RestartGame();

            }
        } 
        
        
        
       
        //turn
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        //jump
        if(Input.GetKeyDown(jumpKey) && isOnGround )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Animator.SetBool("isOnGround", isOnGround);

            playerAudio.PlayOneShot(jumpsound, 1.0f);

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

            //Bad.  Adjust this. 

            DeathSound.Play();
            //highscore
            Debug.Log("Dead. score: " + Gamemanager.score + " HighScore: " + highScoreManager.highscore);
            if(Gamemanager.score > highScoreManager.highscore)
            {
                Debug.Log("High Score Acheived.");
                highScoreManager.SavePrefs();
            }

        }


    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("ScoreBox"))
        {
            Gamemanager.UpdateScore(5);

            
        }
        if (other.gameObject.CompareTag("ScoreBox2"))
        {
            Gamemanager.UpdateScore(7);



        }
    }
   





}
