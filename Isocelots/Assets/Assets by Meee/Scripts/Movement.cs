using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

   
public class Movement : MonoBehaviour {
    
    
    private Rigidbody2D thisObject;
   // private Animator spwiteAnim;
    public float h;
    public float v;
    

    private void Start()
    {
        //spwiteAnim = this.gameObject.GetComponent<Animator>();
        thisObject = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

       /* spwiteAnim.SetFloat("H", h);

        spwiteAnim.SetFloat("V", v);*/
        
    }

    //This is the code that allows topdown 2d movement.
    private void Move(float x, float y)
    {
      
        x = x * 0.15f;
        y = y * 0.15f;


        gameObject.GetComponent<Transform>().Translate(x, y, 0);
    }


    private void FixedUpdate()
    {
        // Read the inputs.




         h = CrossPlatformInputManager.GetAxis("Horizontal");
         v = CrossPlatformInputManager.GetAxis("Vertical");

        if(h > 1)
        {
            h -= .5f;
        }
        if (h < -1)
        {
            h += .5f;
        }
        if (v > 1)
        {
            v -= .5f;
        }
        if (v < -1)
        {
            v += .5f;
        }

        // Pass all parameters to the character control script.
        Move(h, v);
    }
}


