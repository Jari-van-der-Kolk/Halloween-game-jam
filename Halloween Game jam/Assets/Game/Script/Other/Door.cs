using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Door : Interaction
{
    enum Direction
    {
        Upstairs,
        DownStairs
    }

    [SerializeField] private Direction direction;
    [SerializeField] private Transform loc; 
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
              PlayerToObjectLocation(loc); 
        }
    }

    public void PlayerToObjectLocation(Transform objLoc)
    {
        PlayerMovement.instance.transform.position = new Vector3(objLoc.position.x, objLoc.position.y - sr.size.y);
    }

    public override string GetDescription()
    {
        if (direction == Direction.Upstairs) return string.Format("Press [E] to go Upstairs"); 
        return string.Format("Press [E] to go Down Stairs");
    }
    
    
    
    
    
}