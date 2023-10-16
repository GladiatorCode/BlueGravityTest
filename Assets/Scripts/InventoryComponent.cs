using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();

    [SerializeField] private int coins;

    public int GetCoins()
    {
        return coins;
    }

    public void ChangeCoins(int value)
    {
        coins += value;
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
