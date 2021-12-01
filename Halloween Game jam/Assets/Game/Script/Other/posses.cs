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

    [SerializeField] private GameObject humanUIPanel;
    [SerializeField] private float playerFollowHeight;
    [SerializeField] private ItemInventory otherInventory;
    
    private IsPossessed p;

    [SerializeField] private BoxCollider2D otherPossesCollider;
    
    
    private void Awake()
    {
        p = GetComponent<IsPossessed>();
        playerObj = GameObject.FindGameObjectWithTag("Ghost");
        PlayerSr = playerObj.GetComponent<SpriteRenderer>();
        playerPos = playerObj.GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        playerRb = playerObj.GetComponent<Rigidbody2D>();

    }


    public override void Interact()
    {
      
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPossessed = !isPossessed;
            playerPos.position = new Vector3(transform.position.x, transform.position.y + playerFollowHeight, 0);
            PlayerSr.sortingOrder = 6;
            if (isPossessed == true)
            {
                PlayerState.instance.walkingMode = PlayerState.WalkingMode.Human;
                otherInventory.enabled = false;
                humanUIPanel.SetActive(true);
                otherPossesCollider.enabled = false;
            }
            else
            {
                PlayerState.instance.walkingMode = PlayerState.WalkingMode.Ghost;
                humanUIPanel.SetActive(false);
                otherInventory.enabled = true;
                otherPossesCollider.enabled = true;
            } 
        }
    }

    private void Update()
    {
        if (isPossessed)
        {

            if (playerRb.velocity.x >= .1f)
            {
                sr.flipX = false;
            }

            if (playerRb.velocity.x <= .1f)
            {
                sr.flipX = true;
            }
        }
        else
        {
        }
    }

    public override string GetDescription()
    {
        if (isPossessed == false) return "Press [P] to Pocess"; 
        return "Press [P] to unpocess";
    }
}