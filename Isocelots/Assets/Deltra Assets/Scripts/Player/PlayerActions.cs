using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public PlayerState playerState;

    //Interaction code, checks if player is busy or DEAD
    private void Interact()
    {
        if ( playerState.busy || playerState.death != true )
        {
            Debug.Log("Interacted");

            playerState.busy = true;
        }
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E) )
        {
            Interact();
        }
    }
}
