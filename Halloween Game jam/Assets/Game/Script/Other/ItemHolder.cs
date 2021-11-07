using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : Interaction
{

    private ItemManager itemManager;
    [SerializeField] private Item item;
    private bool hasBeenInteractedWith;
    private BoxCollider2D collider;

    private void Awake()
    { 
        collider = GetComponent<BoxCollider2D>();
        itemManager = FindObjectOfType<ItemManager>();
        itemManager.Subscribe(this);
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasBeenInteractedWith == false)
        {
            hasBeenInteractedWith = true;
            if(item != null)Instantiate(item, transform.position, quaternion.identity);
        }
    }

    public override string GetDescription()
    {
        if (hasBeenInteractedWith == false) return "Press [E] to search";
        if (hasBeenInteractedWith == true && item == null) return "Nothing to find here";
        return "Empty";
    }

    public void GetItem(Item item)
    {
        this.item = item;  
    }

    private void Update()
    {
        if (hasBeenInteractedWith)
        {
            collider.enabled = false;
        }
    }
}
