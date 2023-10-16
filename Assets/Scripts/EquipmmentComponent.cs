using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmmentComponent : MonoBehaviour
{

    public static EquipmmentComponent Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    Item equippedItem;

    [SerializeField] GameObject equipmentWidget;

    [SerializeField] Transform equipmentTransform;

    public void EquipItem(Item item)
    {
        equippedItem = item;
        UpdateEquipment();
    }

    public void UpdateEquipment()
    {
        foreach (Transform child in equipmentTransform)
        {
            Destroy(child.gameObject);
        }

        GameObject itemWidgetClone = Instantiate(equipmentWidget,  equipmentTransform);
        itemWidgetClone.GetComponent<ItemWidget>().SetItem(equippedItem);
    }

}
