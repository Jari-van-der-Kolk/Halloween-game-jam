using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posses : Interaction
{
    
    public bool isPossessed;
    private SpriteRenderer PlayerSr;
    private Rigidbody2D playerRb;
    private GameObject playerObj;
    private Transform playerPos;
    private SpriteRenderer sr;

    [SerializeField] private float playerFollowHeight;

    private IsPossessed p;

    [SerializeField] private BoxCollider2D otherPossesCollider;
    
    
    private void Awake()
    {
        p = GetComponent<IsPossessed>();
        playerObj = GameObject.FindGameObjectWithTag("Ghost");
        PlayerSr = playerObj.GetComponent<SpriteRenderer>();
        playerPos = playerObj.GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();

    }


    public override void Interact()
    {
      
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPossessed = !isPossessed;
            playerPos.position = new Vector3(transform.position.x, transform.position.y + playerFollowHeight, 0);
            PlayerSr.sortingOrder = 1;
            if (isPossessed == true)
            {
                PlayerState.instance.walkingMode = PlayerState.WalkingMode.Human;
                otherPossesCollider.enabled = false;
            }
            else
            {
                PlayerState.instance.walkingMode = PlayerState.WalkingMode.Ghost;
                otherPossesCollider.enabled = true;
            } 
        }
        
      

    }

    public override string GetDescription()
    {
        if (isPossessed == false) return "Press [P] to Pocess"; 
        return "Press [P] to unpocess";
    }
}