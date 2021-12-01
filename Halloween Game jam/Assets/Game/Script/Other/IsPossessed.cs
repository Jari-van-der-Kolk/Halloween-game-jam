using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class IsPossessed : MonoBehaviour
{

    private posses posses;
    
    private Transform playerPos;
    private SpriteRenderer PlayerSr;
    private SpriteRenderer sr;
    [SerializeField] private GameObject humanInteraction;
    private Rigidbody2D playerRb;
    private Rigidbody2D rb;
    [SerializeField] private float followHeight;

    
    private GameObject playerObj;
    [SerializeField] private GameObject playerInteract;

    
    private void Awake()
    {
        posses = GetComponent<posses>();
        playerObj = GameObject.FindGameObjectWithTag("Ghost");
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

  

    private void Update()
    {
        if (posses.isPossessed == true)
        {
            
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y + followHeight, 0);
            PlayerSr.sortingOrder = -1;
            humanInteraction.SetActive(true);
            playerRb.gravityScale = 0;
            
            rb.gravityScale = 0;
        }
        else
        {
            playerRb.gravityScale = 0;
            rb.gravityScale = 1;
            
            humanInteraction.SetActive(false);
        }
        
       
    }
}
