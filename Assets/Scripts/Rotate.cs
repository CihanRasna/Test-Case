using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float smoothness = 0.1f;
    
    [SerializeField] private GameObject road;
    
    public static bool isGrounded;
    public static bool isAngleClose;

    private void Start()
    {
        isAngleClose = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        road = other.gameObject;
        isGrounded = true;
        var angleBetween = Quaternion.Angle(road.transform.rotation, transform.rotation);
        isAngleClose = angleBetween < 15f;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            RotateObject();
        }
    }

    private void RotateObject()
    {
        var targetRotation = new Vector3(0, 0, 0);
        var rotate = Quaternion.Euler(targetRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, smoothness * Time.deltaTime);
        road.transform.rotation = Quaternion.Lerp(road.transform.rotation, rotate, smoothness * Time.deltaTime);
    }
}