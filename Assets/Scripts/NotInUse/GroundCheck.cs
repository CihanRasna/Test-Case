using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera floatCam;
    
     public static bool isGrounded = false;
    void OnTriggerEnter(Collider other)
    {
         isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    private void Update()
    {
        if (isGrounded)
        {
            mainCam.Priority = 11;
            floatCam.Priority = 10;
        }
        else
        {
            mainCam.Priority = 10;
            floatCam.Priority = 11;
        }
    }
}
