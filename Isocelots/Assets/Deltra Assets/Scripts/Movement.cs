using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

   
public class Movement : MonoBehaviour {
    
    private Rigidbody2D thisObject;
    // private Animator spwiteAnim;

    public float speed;

    public float horizontal;
    public float vertical;
    
    private void Start()
    {
        //spwiteAnim = this.gameObject.GetComponent<Animator>();

        thisObject = gameObject.GetComponent<Rigidbody2D>();
    }

    //This is the code that allows topdown 2d movement.
    private void Move(Vector2 move)
    {
        gameObject.GetComponent<Transform>().Translate(move.x * speed * Time.deltaTime, move.y * speed * Time.deltaTime, 0);
    }

    private void Update()
    {
        // Read the inputs.
        Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));

        // Pass all parameters to the character control script.
        Move(movement);



        /* spwiteAnim.SetFloat("H", h);

        spwiteAnim.SetFloat("V", v);*/
    }
}


