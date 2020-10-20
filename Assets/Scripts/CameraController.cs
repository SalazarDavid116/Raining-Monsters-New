using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Instance field
    public Transform target;

    private Vector2 lastPosition;

    public float heightMIN, heightMAX;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x,Mathf.Clamp(target.position.y, 
            heightMIN, heightMAX), transform.position.z);
        
        Vector2 moveAmount = new Vector2(transform.position.x - lastPosition.x, 
            transform.position.y - lastPosition.y);
        
        lastPosition = transform.position;
    }
}