using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCollider : MonoBehaviour
{
    public List<Interactable> interactableObjects;

    //On collision, check if the other has the "Interactable" tag, and if so, add its script to the list.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            interactableObjects.Add(other.gameObject.GetComponent<Interactable>());
        }
    }

    //On leaving the collider, remove script from the list if there.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            interactableObjects.Remove(other.gameObject.GetComponent<Interactable>());
        }
    }
}
