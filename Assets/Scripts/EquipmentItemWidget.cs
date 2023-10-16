using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItemWidget : ItemWidget
{
    InventoryComponent playerInventory;

    void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<InventoryComponent>();
    }

    public override void UseItem()
    {
        playerInventory.AddItem(GetItem());

        UIManager.Instance.UpdateInventory();

        CharacterCustomizer.Instance.ChangeArmor("DefaultArmor");

        Destroy(this.gameObject);
    }

    private void ClearItem()
    {
        SetItem(new Item());
    }

}
