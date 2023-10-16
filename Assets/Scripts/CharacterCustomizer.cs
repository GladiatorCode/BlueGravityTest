using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomizer : MonoBehaviour
{
    [SerializeField] GameObject DefaultArmor;
    [SerializeField] GameObject Armor1;
    [SerializeField] GameObject Armor2;

    // Singleton instance
    public static CharacterCustomizer Instance { get; private set; }

    private void Awake()
    {
        // Ensure only one instance of the CharacterCustomizer exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeArmor(string newArmorName)
    {
        switch (newArmorName)
        {
            case "DefaultArmor":
                DefaultArmor.SetActive(true);
                Armor1.SetActive(false);
                Armor2.SetActive(false);
                DefaultArmor.transform.SetAsFirstSibling();
                break;
            case "Armor1":
                DefaultArmor.SetActive(false);
                Armor1.SetActive(true);
                Armor2.SetActive(false);
                Armor1.transform.SetAsFirstSibling();
                break;
            case "Armor2":
                DefaultArmor.SetActive(false);
                Armor1.SetActive(false);
                Armor2.SetActive(true);
                Armor2.transform.SetAsFirstSibling();
                break;
            default:
                break;
        }
        GetComponent<Animator>().Rebind();
        
    }

}
