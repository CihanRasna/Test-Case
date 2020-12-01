using System;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float groundSpeed = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * velocity;
        if (!Rotate.isGrounded)
        {
            PlayerRotate();
            MidPoint();
        }
        else
        {
            PlayerMove();
        }
    }

    private void PlayerRotate()
    {
        if (!Input.GetMouseButton(0)) return;
        var playerInput = Input.GetAxis("Mouse X") * rotateSpeed;
        transform.Rotate(0, 0, -playerInput);
    }

    private void PlayerMove()
    {
        if (!Input.GetMouseButton(0)) return;
        var playerInput = Input.GetAxis("Mouse X") * groundSpeed * Time.deltaTime;
        var position = transform.position;
        position = new Vector3(Mathf.Clamp(playerInput + position.x, -0.2f, 0.2f), 0, position.z);
        transform.position = position;
    }

    void MidPoint()
    {
        var position = transform.position;
        position = Vector3.Lerp(position, new Vector3(0, 0, position.z), 1f * Time.deltaTime);
        transform.position = position;
    }
}