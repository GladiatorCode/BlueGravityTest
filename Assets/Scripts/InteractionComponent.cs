using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionComponent : MonoBehaviour
{
    [SerializeField] GameObject PressEText;
    InteractInterface interactable;

    GameObject eTextClone;
    private void OnTriggerEnter2D (Collider2D other)
    {
        // Check if the trigger collider has collided with a specific tag
        if (other.CompareTag("Interactable"))
        {
            interactable = other.GetComponent<InteractInterface>();

            Vector3 spawnPosition = new Vector3(other.transform.position.x, other.transform.position.y + 5, other.transform.position.z);
            eTextClone = Instantiate(PressEText,  spawnPosition, Quaternion.identity);
            // Perform actions when the trigger is entered by the player
            Debug.Log("Player entered the trigger area.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the trigger collider has stopped colliding with a specific tag
        if (other.CompareTag("Interactable"))
        {
            interactable = null;
            // Perform actions when the trigger is exited by the player
            Debug.Log("Player exited the trigger area.");
            Destroy(eTextClone);
        }
    }

    void Update()
    {
        if(interactable != null && Input.GetKeyDown(KeyCode.E))
        {
            interactable.OnInteract();
        }
    }

}
