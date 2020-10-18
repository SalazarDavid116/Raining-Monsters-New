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

    public int health;
    public int score;

    private Rigidbody2D rb;
    public Animator anim;

    private void Awake() { instance = this; } 
    
    //--------------------------------------------------------------------------
    // Main functions
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scoreDisplay.text = "Score = " + score.ToString();
        finalScoreDisplay.text = scoreDisplay.text;
        score = 0;
    }

    // Update is called once per frame
    private void Update()
    {
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
        
    } // function - Update()

    // FixedUpdate (30 or 60 FPS)
    void FixedUpdate()
    {
        // Stores player's input
        hInput = Input.GetAxisRaw("Horizontal");

        // Moving player
        rb.velocity = new Vector2(hInput * speed, rb.velocity.y);

    } // function - FixedUpdate()
    
    //--------------------------------------------------------------------------
    // Added functions
    
    // function - Player taking damages
    public void TakeDamage(int damageAmount)
    {
        //Health deceases when hit
        health -= damageAmount;
        score--;

        // If health == 0: Player destroyed
        if (health <= 0) {
            Destroy(gameObject);
            finalScoreDisplay.text = "Score = " + score.ToString();
            lostPanel.SetActive(true);
        }
    } // function - TakeDamage
}
