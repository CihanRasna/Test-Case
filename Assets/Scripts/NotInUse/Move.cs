using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float inputSpeed = 5f;
    [SerializeField] private float groundSpeed = 1f;
    
    private Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed ;
        if (!GroundCheck.isGrounded)
        {
           PlayerRotate(); 
        }
    }

    private void PlayerRotate()
    {
        var playerInput = Input.GetAxis("Horizontal") * inputSpeed;
        transform.Rotate(0,0,-playerInput);
    }

    private void PlayerMove()
    {
        var playerInput = Input.GetAxis("Horizontal") * groundSpeed *Time.deltaTime;
        transform.localPosition += new Vector3(playerInput,0,0);
    }
}
