using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    
    public int damage;
    public GameObject explosion;

    private void Awake() { instance = this; }

    // ---------------------------------------------------------------
    // Main functions
    
    // Start is called before the first frame update
    void Start()
    {
    } // function - Start()
    
    // Update is called once per frame
    void Update()
    {
    } // function - Update()
    
    // ---------------------------------------------------------------
    // Added functions
    
    // Trigger (Monster)
    //void OnTriggerEnter2D(Collider2D hitObject)
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            PlayerController.instance.anim.SetTrigger("damage");
            PlayerController.instance.TakeDamage(damage);
            PlayerController.instance.scoreDisplay.text = "Score = " + PlayerController.instance.score.ToString();
            Instantiate(explosion, transform.position, quaternion.identity);
            Destroy(gameObject);
        } else if (hitObject.tag == "Ground")
        {
            PlayerController.instance.score++;
            PlayerController.instance.scoreDisplay.text = "Score = " + PlayerController.instance.score.ToString();
            Instantiate(explosion, transform.position, quaternion.identity);
            Destroy(gameObject, 0.5f);
        }
    } // function - onTriggerEnter()
}
