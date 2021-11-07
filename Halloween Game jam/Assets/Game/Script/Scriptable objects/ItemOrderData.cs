using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item collect order")]
public class ItemOrderData : ScriptableObject
{
   public Item[] ItemOrder;
}
