using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    
    [SerializeField] private Vector2 input;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ;
    }

    private void FixedUpdate()
    {  
        switch (PlayerState.instance.walkingMode)
        {
            case PlayerState.WalkingMode.Ghost:
                //rb.gravityScale = 0;
                rb.velocity = new Vector3(input.x, input.y) * (speed * Time.deltaTime) ;
                break;
            case PlayerState.WalkingMode.Human:
                rb.velocity = new Vector3(input.x, 0) * (speed * Time.deltaTime) ;
                //rb.gravityScale = 1;
                break;
        }
    }
}
