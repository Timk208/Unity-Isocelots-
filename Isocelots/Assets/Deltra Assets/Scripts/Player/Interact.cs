using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public PlayerMovement playerMovement;

    //Rotate with the player's last direction angle.
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, playerMovement.lastDirection + 90);
    }
}
