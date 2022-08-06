using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    //Activatable Script



    //---------------------------------------------------------------------------



    //All activatable objects will be coded in this script.
    //When coding a new one, add a case to the switch statement.
    //Explaining the variables used with Tooltips/Headers is helpful as well.



    //---------------------------------------------------------------------------



    [Tooltip("0: Enable/Disable")]
    public int activateType;

    [Header("Enable/Disable Options")]
    [Space(10)]
    [Tooltip("Object to enable/disable.")]
    [Rename("Object")]
    public GameObject enableDisableObject;

    [HideInInspector]
    public bool activated = false;



    //---------------------------------------------------------------------------



    void Update()
    {
        if (activated)
        {
            switch (activateType)
            {



                case 0: //Enable/Disable

                    enableDisableObject.SetActive(!enableDisableObject.activeSelf);

                    activated = false;

                    break;



            }
        }
    }
}
