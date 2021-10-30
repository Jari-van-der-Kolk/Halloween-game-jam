using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PlayerMovement : MonoBehaviour
{
    enum WalkingMode
    {
        Human,
        Ghost
    }

    [SerializeField] private WalkingMode walkingMode;
    [SerializeField] private Vector2 input;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (walkingMode)
        {
            case WalkingMode.Ghost:
                rb.gravityScale = 0;
                break;
            case WalkingMode.Human:
                rb.gravityScale = 1;
                break;
        }
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * (speed * Time.deltaTime);
    }

    private void FixedUpdate()
    { 
        transform.position += new Vector3(input.x, input.y);
    }
}
