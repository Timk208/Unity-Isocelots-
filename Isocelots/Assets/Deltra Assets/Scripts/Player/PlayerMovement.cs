using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

   
public class PlayerMovement : MonoBehaviour {

    // private Animator spwiteAnim;

    public float speed;

    public float horizontal;
    public float vertical;

    public PlayerState playerState;

    private void Start()
    {
        //spwiteAnim = this.gameObject.GetComponent<Animator>();
    }

    //This is the code that allows topdown 2d movement.
    private void Move(Vector2 move)
    {
        gameObject.GetComponent<Rigidbody>().velocity = move * speed;
    }

    private void FixedUpdate()
    {
        // Read the inputs, normalize if diagonal.
        Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));

        if (movement.sqrMagnitude > 1) { movement.Normalize(); }

        // Pass all parameters to the character control script.
        if ( playerState.busy == false && playerState.death == false )
        {
            Move(movement);
        }

        /* spwiteAnim.SetFloat("H", h);

        spwiteAnim.SetFloat("V", v);*/
    }
}


