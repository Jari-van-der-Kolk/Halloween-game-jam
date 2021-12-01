using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stove : MonoBehaviour
{
    [SerializeField] private int indexOrder;
    [SerializeField] private int ItemOrderListIndex;
    [SerializeField] private ItemOrderData[] itemOrderData;
    [SerializeField] private TextMeshProUGUI getItemUI;
    [SerializeField] private GameObject winPanel;
     
    void Start()
    {
        ItemOrderListIndex = Random.Range(0, itemOrderData.Length);
        indexOrder = 0;
        winPanel.SetActive(false);
    }

    void Update()
    {
        if(indexOrder < itemOrderData[ItemOrderListIndex].ItemOrder.Length)
            getItemUI.text = "Get " + itemOrderData[ItemOrderListIndex].ItemOrder[indexOrder].name;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item") && (other.GetComponent<Item>().itemData.name == itemOrderData[ItemOrderListIndex].ItemOrder[indexOrder].name))
        {
            other.gameObject.SetActive(false);
            indexOrder++;
            //Debug.Log(indexOrder > itemOrderData[ItemOrderListIndex].ItemOrder.Length);
            if (indexOrder >= itemOrderData[ItemOrderListIndex].ItemOrder.Length)
            {
                Time.timeScale = 0f;
                winPanel.SetActive(true);                
            }
        }
    }
}
