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

    [Tooltip("0: Text\n1: Button")]
    public int interactionType;

    [Header("Text Options")]
    [Space(10)]
    [Tooltip("TextObject to display from.")]
    public TextObject textData;
    //[Tooltip("Should the textbox show a frame?")]
    //public bool frame;

    [HideInInspector]
    public bool activated = false;

    //---------------------------------------------------------------------------

    private void Awake()
    {
        //Assigns interactable tag to object script is on.
        gameObject.tag = "Interactable";
    }

    void Update()
    {
        if (activated)
        {
            switch(interactionType)
            {
                case 0: //Text

                    GameObject.Find("TextBox").GetComponent<TextBox>().AddText(textData);

                    activated = false;

                    break;
            }
        }
    }
}
