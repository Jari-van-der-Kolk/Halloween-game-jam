using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public Item item;


    public void AddItem(Item item)
    {
        if (this.item != null)
        {
            this.item.transform.position = transform.position;
            this.item.gameObject.SetActive(true);
            this.item = item;
        }
        else
        {
            this.item = item;
        }
    }

    private void DropCurrentItem()
    {
        if (Input.GetKeyDown(KeyCode.C) && item != null)
        {
            item.transform.position = transform.position;
            item.gameObject.SetActive(true);
        }   
    }
    
    private void Update()
    {
       DropCurrentItem();
    }
}
