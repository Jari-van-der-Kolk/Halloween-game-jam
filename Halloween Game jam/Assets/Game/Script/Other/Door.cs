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
    [SerializeField] private float spawnHeight;

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
        PlayerMovement.instance.transform.position = new Vector3(objLoc.position.x, objLoc.position.y + spawnHeight);
    }

    public override string GetDescription()
    {
        if (direction == Direction.Upstairs) return string.Format("Press [E] to go Upstairs"); 
        return string.Format("Press [E] to go Down Stairs");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.CompareTag("Human")) spawnHeight = -.35f;
        if (other.CompareTag("Mouse")) spawnHeight = -1.9f;*/
    }
}
