using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cloudy : MonoBehaviour
{
    public float speed;
    
    // ---------------------------------------------------------------
    // Added functions
    
    // Trigger (Monster)
    //void OnTriggerEnter2D(Collider2D hitObject)
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "CloudyWall") {
            Destroy(gameObject);
        }
    }

    // ---------------------------------------------------------------
    // Main functions
    
    // Start is called before the first frame update
    void Start()
    {
        
    } // function - Start()

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.left * (speed * Time.deltaTime));
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    } // function - Update()
}
