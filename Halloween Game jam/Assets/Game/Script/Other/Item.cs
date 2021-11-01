using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interaction
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private Vector2 size;
    [SerializeField] private LayerMask layermask;
    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spr.sprite = itemData.image;
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var hit = Physics2D.BoxCast(transform.position, size, 0, Vector2.up, 0, layermask);
            if (hit.collider.GetComponent<ItemInventory>() != null)
            {
                hit.collider.GetComponent<ItemInventory>().AddItem(this);
                gameObject.SetActive(false);
            }
        }
    }

    public override string GetDescription()
    {
        return "Press [F] to pick up " + itemData.name;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}
