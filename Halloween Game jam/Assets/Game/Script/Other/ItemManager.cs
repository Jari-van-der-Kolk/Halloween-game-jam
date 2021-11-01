using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    
    public List<Item> Items;
    public List<ItemHolder> itemHolders;

    private RandomizeOrder<ItemHolder> randomizeItemHolderOrder;
    private RandomizeOrder<Item> randomizeItemOrder;

    [SerializeField] private int numberOfItems;

    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        randomizeItemHolderOrder = new RandomizeOrder<ItemHolder>(itemHolders.ToArray());
        randomizeItemOrder = new RandomizeOrder<Item>(Items.ToArray());
        randomizeItemOrder.Shuffle();
        randomizeItemHolderOrder.Shuffle();
        PlaceItems();
    }
    public void Subscribe(ItemHolder itemHolder)
    {
        itemHolders.Add(itemHolder);
    }

    private void PlaceItems()
    {
        numberOfItems = Mathf.Clamp(numberOfItems, 0, Items.Count);
        for (int i = 0; i < numberOfItems; i++)
        {
           randomizeItemHolderOrder.Next().GetItem(randomizeItemOrder.Next());
        }
    }
    
}
