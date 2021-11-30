using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
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
    [SerializeField] private GameObject humanUIPanel;
    [SerializeField] private GameObject AI;
    [SerializeField] private Patrol patrol;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private float followHeight;

    
    private GameObject playerObj;

    
    private void Awake()
    { 
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
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y + followHeight, 0);
            PlayerSr.sortingOrder = -1;
            humanInteraction.SetActive(true);
            playerRb.gravityScale = 0;

            if (playerRb.velocity.x >= .1f)
            {
                sr.flipX = false;
            }

            if (playerRb.velocity.x <= .1f)
            {
                sr.flipX = true;
            }
            /*playerObj.GetComponent<PlayerMovement>().enabled = false;
            humanMovement.enabled = true;*/
            
            rb.gravityScale = 1;
            humanUIPanel.SetActive(true);
            aiPath.enabled = false;
            patrol.enabled = false;

        }
        else
        {
            PlayerState.instance.walkingMode = PlayerState.WalkingMode.Ghost;
            playerRb.gravityScale = 0;
            rb.gravityScale = 1; 

            /*playerObj.GetComponent<PlayerMovement>().enabled = true;
            humanMovement.enabled = false;*/
            
            humanInteraction.SetActive(false);
            humanUIPanel.SetActive(false);
            aiPath.enabled = true;
            patrol.enabled = true;
            if (aiPath.velocity.x >= .1f)
            {
                sr.flipX = false;
            }

            if (aiPath.velocity.x <= .1f)
            {
                sr.flipX = true;
            }
        }

        /*if (aiPath.velocity.x >= .1f)
        {
            Debug.Log("Bitch");
        }

        if (aiPath.velocity.x <= .1f)
        {
            Debug.Log("Fuck you");
        }*/
    }
}
