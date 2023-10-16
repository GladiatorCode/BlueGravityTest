using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blacksmith : MonoBehaviour, InteractInterface
{
    public void OnInteract()
    {
        Debug.Log("Interacting with blacksmith");
        UIManager.Instance.OpenShop();
        UIManager.Instance.OpenInventory();
    }

}
