using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPossessed : Interaction
{
    [SerializeField] private bool isPossessed;

    private Transform playerPos;
    private SpriteRenderer PlayerSr;
    private SpriteRenderer sr;
    [SerializeField] private GameObject humanInteraction;
    private Rigidbody2D playerRb;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        var playerObj = GameObject.FindGameObjectWithTag("Ghost");
        PlayerSr = playerObj.GetComponent<SpriteRenderer>();
        sr = GetComponent<SpriteRenderer>();
        playerPos = playerObj.GetComponent<Transform>();
        playerRb = playerObj.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        humanInteraction.SetActive(false);
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPossessed = !isPossessed;  
            playerPos.position = new Vector3(transform.position.x, transform.position.y - sr.size.y, 0);
            PlayerSr.sortingOrder = 1;
        }

        
    }

    public override string GetDescription()
    {
        if (isPossessed == false) return "Press [P] to Pocess human"; 
        return "Press [P] to unpocess human";
    }

    private void Update()
    {
        if (isPossessed == true)
        {
            PlayerState.instance.walkingMode = PlayerState.WalkingMode.Human;
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y + sr.size.y, 0);
            PlayerSr.sortingOrder = -1;
            humanInteraction.SetActive(true);
            playerRb.gravityScale = 1;
            rb.gravityScale = 0;
        }
        else
        {
            PlayerState.instance.walkingMode = PlayerState.WalkingMode.Ghost;
            playerRb.gravityScale = 0;
            rb.gravityScale = 1; 
            humanInteraction.SetActive(false);
        }
    }
}
