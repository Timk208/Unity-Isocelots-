using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    public int choiceNumber;

    public Choices choices;



    // On click, send this object's answerNumber to the choices script.
    public void Click()
    {
        choices.Answer(choiceNumber);
    }
}
