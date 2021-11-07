using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInventory : MonoBehaviour
{
    public Item item;
    [SerializeField] private Image holdingItemUI;
    [SerializeField] private Sprite emptyItemUI;
    [SerializeField] private bool hasItem;
    [SerializeField] private IsPossessed isPossessed;
    [SerializeField] private TextMeshProUGUI keybindDescription;
    [SerializeField] private TextMeshProUGUI holdingItemNameUI;   


    private void Awake()
    {
        isPossessed = GetComponent<IsPossessed>();
    }

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

    private void SwitchCurrentItem()
    {
        if (Input.GetKeyDown(KeyCode.C) && item != null)
        {
            item.transform.position = transform.position;
            item.gameObject.SetActive(true);
        }   
    }
    
    private void Update()
    {
       SwitchCurrentItem();
       DropItem();
       if (item != null) hasItem = true;
       else hasItem = false;
       ShowUi();
    }

    private void DropItem()
    {
        if (hasItem == true && Input.GetKeyDown(KeyCode.Q))
        {
            item.transform.position = transform.position;
            item.gameObject.SetActive(true);
            item = null;
        }
    }

    private void ShowUi()
    {
        if (hasItem)
        {
            holdingItemUI.sprite = item.itemData.image;
            keybindDescription.text = "Press [Q] to drop item";
            holdingItemNameUI.text = "Holding: " + item.name;
        }
        else
        {
            holdingItemUI.sprite = emptyItemUI;
            keybindDescription.text = "";
            holdingItemNameUI.text = "";
        }
    }
}
