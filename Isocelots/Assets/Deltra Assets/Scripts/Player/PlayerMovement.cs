using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

   
public class PlayerMovement : MonoBehaviour {

    // private Animator spwiteAnim;

    public float speed;

    public float horizontal;
    public float vertical;

    public float lastDirection;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();

        //spwiteAnim = this.gameObject.GetComponent<Animator>();
    }

    //This is the code that allows topdown 2d movement.
    private void Move(Vector2 move)
    {
        playerRigidbody.velocity = move * speed; //Apparently setting velocity per FixedUpdate is bad, change later?
    }

    //Sets the last direction player was moving.
    private void LastDirection()
    {
        if (playerRigidbody.velocity != Vector3.zero)
        {
            lastDirection = Vector3.SignedAngle(Vector3.up, playerRigidbody.velocity, Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
        // Read the inputs, normalize if diagonal.
        Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));

        if (movement.sqrMagnitude > 1) { movement.Normalize(); }

        // Pass all parameters to the character control script.
        if (PlayerState.Instance.busy != true && PlayerState.Instance.death != true)
        {
            Move(movement);
        }
        else
        {
            playerRigidbody.velocity = Vector3.zero;
        }

        LastDirection();

        /* spwiteAnim.SetFloat("H", h);

        spwiteAnim.SetFloat("V", v);*/
    }
}


