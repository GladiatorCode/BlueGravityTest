using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemWidget : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Image itemImage;

    InventoryComponent playerInventory;

    void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<InventoryComponent>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        Init();
    }

    public Item GetItem()
    {
        return item;
    }

    public virtual void UseItem()
    {
        if(UIManager.Instance.shopOpened)
        {
            playerInventory.RemoveItem(GetItem());
            playerInventory.ChangeCoins(GetItem().price);
            UIManager.Instance.UpdateInventory();
            return;
        }

        EquipmmentComponent.Instance.EquipItem(GetItem());

        playerInventory.RemoveItem(GetItem());

        CharacterCustomizer.Instance.ChangeArmor(item.itemName);

        UIManager.Instance.UpdateInventory();
    }

    public void Init()
    {
        itemImage.sprite = item.itemImage;
    }
}
