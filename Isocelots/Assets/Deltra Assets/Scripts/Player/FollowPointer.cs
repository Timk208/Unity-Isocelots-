using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class FollowPointer : MonoBehaviour {
    //private Touch followT;
    public int Grabstate = 0;
    private Transform playerBody;
    //[SerializeField] Animator spriteAnim;
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed = 5.0f;
    public GameObject heldObject;

    public float horizontal;
    public float vertical;

    public Rigidbody rb;
    public float forceAmount = 10;

    // Use this for initialization
    void Start () {
        
        playerBody = player.GetComponent<Transform>();
        //followT = new Touch();
	}



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Weight>() && Grabstate == 0)
        {
            heldObject = collider.gameObject;
            Grabstate = collider.GetComponent<Weight>().objectWeight;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       

        /*if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // If the finger is on the screen, move the object smoothly to the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                transform.position = touchPosition;
            }
        }*/

        //if (Input.GetMouseButtonDown(0))
        // {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = touchPosition;
        //}

        float move = moveSpeed * Time.deltaTime;

        playerBody.position = Vector2.MoveTowards(playerBody.position, transform.position, move);

        horizontal = (transform.position.x - playerBody.position.x);
        vertical = (transform.position.y - playerBody.position.y);

        switch (Grabstate)
        {
            case 0:
                break;

            case 1:
                
                Rigidbody rigidBody = heldObject.GetComponent<Rigidbody>();
               
                rigidBody.transform.LookAt(this.transform);
                rigidBody.velocity = heldObject.transform.forward * 7;

                

                break;
        }

        if (Input.GetMouseButtonDown(0) && Grabstate == 0 && heldObject == null && Input.GetMouseButtonDown(1) != true)
        {
            this.GetComponent<BoxCollider>().enabled = true;
        }

        else if (Input.GetMouseButtonUp(0) && Grabstate == 0 && heldObject == null)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }

        if (Input.GetMouseButtonDown(1) && Grabstate != 0 && heldObject != null)
        {
            Grabstate = 0;
            heldObject = null;

        }

        /*spriteAnim.SetFloat("H", h);
        spriteAnim.SetFloat("V", v);*/
    }
}
