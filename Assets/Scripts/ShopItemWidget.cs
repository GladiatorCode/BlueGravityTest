using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemWidget : ItemWidget
{
    InventoryComponent playerInventory;

    void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<InventoryComponent>();
    }

    public override void UseItem()
    {
        Debug.Log("Buy");

        if(GetItem().price <= playerInventory.GetCoins())
        {
            playerInventory.AddItem(GetItem());
            playerInventory.ChangeCoins(-GetItem().price);
            UIManager.Instance.UpdateInventory();
        }
        
    }
}
