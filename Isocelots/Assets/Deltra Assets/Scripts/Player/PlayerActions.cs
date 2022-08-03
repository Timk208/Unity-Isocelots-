using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public PlayerState playerState;

    public GameObject textBox;

    private void Start()
    {
        textBox.SetActive(true);
    }

    //Interaction code, checks if player is busy or DEAD
    private void Interact()
    {
        if ( playerState.busy || playerState.death != true )
        {
            Debug.Log("Interacted");

            playerState.busy = true;
        }
    }

    private void InteractText()
    {
        textBox.SetActive(true);
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E) )
        {
            Interact();
        }
    }
}
