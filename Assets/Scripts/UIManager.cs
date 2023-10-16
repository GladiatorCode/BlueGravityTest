using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public bool shopOpened = false;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject shopInventory;
    [SerializeField] InventoryComponent playerInventoryComponent;
    [SerializeField] InventoryComponent shopInventoryComponent;
    [SerializeField] GameObject itemWidget;
    [SerializeField] GameObject shopItemWidget;
    [SerializeField] Transform inventoryGridTransform;
    [SerializeField] Transform shopGridTransform;
    [SerializeField] TMP_Text CoinsValue; 

    public static UIManager Instance { get; private set; }

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

    void Start()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        // Remove all children from the inventory grid
        foreach (Transform child in inventoryGridTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in shopGridTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in playerInventoryComponent.GetItems())
        {
            GameObject itemWidgetClone = Instantiate(itemWidget,  inventoryGridTransform);
            itemWidgetClone.GetComponent<ItemWidget>().SetItem(item);
        }

        SetPlayerCoinsValueInUI();

        foreach (Item item in shopInventoryComponent.GetItems())
        {
            GameObject itemWidgetClone = Instantiate(shopItemWidget,  shopGridTransform);
            itemWidgetClone.GetComponent<ItemWidget>().SetItem(item);
        }
    }

    public void SetPlayerCoinsValueInUI()
    {
        CoinsValue.text = playerInventoryComponent.GetCoins().ToString();
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
    }

    public void OpenShop()
    {
        shopInventory.SetActive(true);
        shopOpened = true;
    }

    public void CloseShop()
    {
        shopInventory.SetActive(false);
        shopOpened = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
    }
}
