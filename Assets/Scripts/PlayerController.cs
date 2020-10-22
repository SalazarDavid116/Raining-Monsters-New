﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    //instance field
    public GameObject lostPanel;
    public GameObject menuPanel;
    public Text scoreDisplay;
    public Text finalScoreDisplay;
    
    public float speedX;
    public float jumpForce;

    public int health;
    public int score;
    
    private Rigidbody2D playerRB;
    public Animator anim;

    private bool isGrounded, isBottomEnd;
    public Transform groundCheckPoint;
    public LayerMask layerGround, bottomEnd;
    
    private bool displayMenu;

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
        
        // Checks if the player fall off platform and fall into bottom
        isBottomEnd = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, bottomEnd);

        // Moving player
        playerRB.velocity = new Vector2(speedX * Input.GetAxisRaw("Horizontal"), playerRB.velocity.y);
        playerSpriteFlip();
        
        // Checks if the player is on the ground
        PlayerOnGround();

        // Display menu when pressing 'esc'
        DisplayGameMenu();

        // If time runs out or player fall off platform - Freeze the game
        if (UIController.instance.timeNumberLength <= 0) {
            gameOver();
        } else if (isBottomEnd) {
            gameOver();
        } // End - if (UIController.timeNumberLength)
        
        //Animations
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("moveSpeed", Mathf.Abs(playerRB.velocity.x));
    } // function - Update()
    
    //--------------------------------------------------------------------------
    // Added functions
    
    // function - Player taking damages
    public void TakeDamage(int damageAmount)
    {
        //Health deceases when hit
        health -= damageAmount;

        // If health == 0: Player destroyed
        if (health <= 0) {
            gameOver();
        }
    } // function - TakeDamage

    // Pauses the game and bring "game over" screen
    public void gameOver()
    {
        Time.timeScale = 0;
        finalScoreDisplay.text = "Score = " + score.ToString();
        lostPanel.SetActive(true);
    } // function - GameOver()

    // Display menu when pressing 'esc'
    public void DisplayGameMenu() {
        if (Input.GetKeyDown(KeyCode.Escape) && displayMenu == false) { 
            displayMenu = true;
        } else if (Input.GetKeyDown(KeyCode.Escape) && displayMenu) {
            displayMenu = false;
        }

        if (displayMenu) {
            menuPanel.SetActive(true);
            Time.timeScale = 0;
        } else if (displayMenu == false) {
            menuPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    // Checks input for flipping player
    public void playerSpriteFlip() {
        if (playerRB.velocity.x < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        } else if (playerRB.velocity.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        } // end if (playerRB.velocity.x)
    }

    // Checks if the player is on the ground
    public void PlayerOnGround() {
        
        if (isGrounded) {
            // player jumping
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            }
        } // End - if (isGrounded)
    }
}
