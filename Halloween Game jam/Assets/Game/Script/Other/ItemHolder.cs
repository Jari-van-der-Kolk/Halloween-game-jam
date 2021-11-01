using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ItemHolder : Interaction
{

    private ItemManager itemManager;
    [SerializeField] private Item item;
    private bool hasBeenInteractedWith;

    private void Awake()
    {
        itemManager = FindObjectOfType<ItemManager>();
        itemManager.Subscribe(this);
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hasBeenInteractedWith = true;
            Instantiate(item, transform.position, quaternion.identity);
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
    
}
