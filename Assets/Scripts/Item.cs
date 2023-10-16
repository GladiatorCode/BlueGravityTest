
using UnityEngine;

[System.Serializable]
public struct Item
{
    public int itemID;
    public string itemName;
    public Sprite itemImage;
    public int price;

    // Constructor for creating an item
    public Item(int itemID, string itemName, Sprite itemImage, int price)
    {
        this.itemID = itemID;
        this.itemName = itemName;
        this.itemImage = itemImage;
        this.price = price;
    }
}