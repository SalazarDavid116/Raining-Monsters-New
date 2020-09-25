using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject lostPanel;
    public Text healthDisplay;
    
    public float speed;
    private float hInput, vInput;

    public int health;

    private Rigidbody2D rb;
    private Animator anim;
    //--------------------------------------------------------------------------
    // Added functions
    
    // function - Player taking damages
    public void TakeDamage(int damageAmount)
    {
        //Health deceases when hit
        health -= damageAmount;
        healthDisplay.text = "HP: " + health.ToString();

        // If health == 0: Player destroyed
        if (health <= 0) {
            Destroy(gameObject);
            healthDisplay.text = "HP: 0";
            lostPanel.SetActive(true);
        }
    } // function - TakeDamage
    
    //--------------------------------------------------------------------------
    // Main functions
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthDisplay.text = "HP: " + health.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (hInput != 0) {
            anim.SetBool("isRunning", true);
            anim.SetBool("isCrouch", false);
        } else if (hInput == 0) {
            anim.SetBool("isRunning", false);
            anim.SetBool("isCrouch", false);
        } else if (vInput < 0) {
            anim.SetBool("isRunning", false);
            anim.SetBool("isCrouch", true);
        } else if (vInput == 0) {
            anim.SetBool("isRunning", false);
            anim.SetBool("isCrouch", false);
        }

        if (hInput > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        } else if (hInput < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        } 
        
        //else if (vInput < 0) { }
    } // function - Update()

    // FixedUpdate (30 or 60 FPS)
    void FixedUpdate()
    {
        // Stores player's input
        hInput = Input.GetAxisRaw("Horizontal");
        //print(input); // Test (console)

        vInput = Input.GetAxisRaw("Vertical");
        //print(inputV); // Test (console)

        // Moving player
        rb.velocity = new Vector2(hInput * speed, rb.velocity.y);
        //rb.velocity = new Vector2(hInput * speed, vInput * speed);

    } // function - FixedUpdate()
}
