using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    //private float speed;
    //public float speedMin;
    //public float speedMax;

    public int damage;
    private Player playerScript;
    public GameObject explosion;

    // ---------------------------------------------------------------
    // Added functions
    
    // Trigger (Monster)
    //void OnTriggerEnter2D(Collider2D hitObject)
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player") {
            playerScript.TakeDamage(damage);
            //print("CAUTION:  MONSTER HIT THE PLAYER!!! Your health = " + playerScript.health);
            Instantiate(explosion, transform.position, quaternion.identity);
            Destroy(gameObject);
            playerScript.scaleSmaller(0.02f);
        } else if (hitObject.tag == "Ground") {
            //print("Monster hit the ground");
            CameraShake.instance.StartShake(0.15f, 0.03f);
            Instantiate(explosion, transform.position, quaternion.identity);
            Destroy(gameObject, 0.5f);
        } 
        
    } // function - onTriggerEnter()
    // ---------------------------------------------------------------
    // Main functions
    
    // Start is called before the first frame update
    void Start()
    {
        //speed = Random.Range(speedMin, speedMax);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    } // function - Start()
    
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.down * (speed * Time.deltaTime));
    } // function - Update()
}
