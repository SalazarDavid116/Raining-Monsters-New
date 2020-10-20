using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    //instance field
    public GameObject lostPanel;
    public Text scoreDisplay;
    public Text finalScoreDisplay;
    
    public float speed;
    private float hInput;
    public float jumpForce;

    public int health;
    public int score;
    
    private Rigidbody2D playerRB;
    public Animator anim;

    private bool isGrounded, isBottomEnd;
    public Transform groundCheckPoint;
    public LayerMask layerGround, bottomEnd;

    private void Awake() { instance = this; } 
    
    //--------------------------------------------------------------------------
    // Main functions
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scoreDisplay.text = "Score = " + score.ToString();
        finalScoreDisplay.text = scoreDisplay.text;
        score = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        // Checks if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, layerGround);
        isBottomEnd = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, bottomEnd);

        if (isGrounded) {
            // player jumping
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            }

            if (hInput != 0) {
                anim.SetBool("isRunning", true);
            } else if (hInput == 0) {
                anim.SetBool("isRunning", false);
            } 

            if (hInput > 0) {
                transform.eulerAngles = new Vector2(0, 0);
            } else if (hInput < 0) {
                transform.eulerAngles = new Vector2(0, 180);
            }
        } // End - if (isGrounded)

        if (UIController.instance.timeNumberLength <= 0) {
            Destroy(gameObject);
            finalScoreDisplay.text = "Score = " + score.ToString();
            lostPanel.SetActive(true);
        } else if (isBottomEnd) {
            Destroy(gameObject);
            finalScoreDisplay.text = "Score = " + score.ToString();
            lostPanel.SetActive(true);
        } // End - if (UIController.timeNumberLength)

        //Animations
        anim.SetBool("isGrounded", isGrounded);

    } // function - Update()

    // FixedUpdate (30 or 60 FPS)
    void FixedUpdate()
    {
        // Stores player's input
        hInput = Input.GetAxisRaw("Horizontal");

        // Moving player
        playerRB.velocity = new Vector2(hInput * speed, playerRB.velocity.y);

    } // function - FixedUpdate()
    
    //--------------------------------------------------------------------------
    // Added functions
    
    // function - Player taking damages
    public void TakeDamage(int damageAmount)
    {
        //Health deceases when hit
        health -= damageAmount;

        // If health == 0: Player destroyed
        if (health <= 0) {
            Destroy(gameObject);
            finalScoreDisplay.text = "Score = " + score.ToString();
            lostPanel.SetActive(true);
        }

    } // function - TakeDamage
}
