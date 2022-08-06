using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Interactable Script



    //---------------------------------------------------------------------------



    //All interactable objects will be coded in this script.
    //When coding a new one, add a case to the switch statement.
    //Explaining the variables used with Tooltips/Headers is helpful as well.



    //---------------------------------------------------------------------------



    [Tooltip("0: Text\n1: Button\n2: Toggle")]
    public int interactionType;

    [Header("Text Options")]
    [Space(10)]
    [Tooltip("TextObject to display from.")]
    [Rename("Text Object")]
    public TextObject textData;
    //[Tooltip("Should the textbox show a frame?")]
    //public bool frame;

    [Header("Button Options")]
    [Space(10)]
    [Tooltip("Object to activate.")]
    [Rename("Object")]
    public GameObject buttonObject;

    [Header("Toggle Options")]
    [Space(10)]
    [Tooltip("Object to toggle.")]
    [Rename("Object")]
    public GameObject toggleObject;

    [HideInInspector]
    public bool interacted = false;

    private bool buttonPressed = false;



    //---------------------------------------------------------------------------



    private void Awake()
    {
        //Assigns interactable tag to object script is on.
        gameObject.tag = "Interactable";
    }



    void Update()
    {
        if (interacted)
        {
            switch(interactionType)
            {



                case 0: //Text

                    GameObject.Find("TextBox").GetComponent<TextBox>().AddText(textData);

                    interacted = false;

                    break;



                case 1: //Button

                    if (!buttonPressed)
                    {
                        buttonObject.GetComponent<Activatable>().activated = true;

                        buttonPressed = true;
                    }

                    break;



                case 2: //Toggle

                    toggleObject.GetComponent<Activatable>().activated = true;

                    interacted = false;

                    break;



            }
        }
    }
}
