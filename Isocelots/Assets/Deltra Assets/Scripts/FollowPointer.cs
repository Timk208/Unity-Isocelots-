using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class FollowPointer : MonoBehaviour {
    //private Touch followT;
   
    private Transform playerBody;
    //[SerializeField] Animator spriteAnim;
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed = 5.0f;

    public float horizontal;
    public float vertical;

    // Use this for initialization
    void Start () {
        
        playerBody = player.GetComponent<Transform>();
        //followT = new Touch();
	}

	// Update is called once per frame
	void Update () {

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

        /*spriteAnim.SetFloat("H", h);
        spriteAnim.SetFloat("V", v);*/
    }
}
