using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public InteractCollider interactCollider;

    public GameObject textBox;

    //Interaction code - checks if any interactable objects are available to activate.
    private void Interact()
    {
        if (interactCollider.interactableObjects.Count != 0)
        {
            interactCollider.interactableObjects[0].activated = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(PlayerState.Instance.busy != true && PlayerState.Instance.death != true)
            {
                Interact();
            }
        }
    }
}
