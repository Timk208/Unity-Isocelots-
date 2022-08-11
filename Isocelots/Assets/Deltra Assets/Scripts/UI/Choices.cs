using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextObjects;
using TMPro;

public class Choices : MonoBehaviour
{

    //---------------------------------------------------------------------------

    // THIS SCRIPT IS KINDA SHITTY - WE COULD PROBABLY UPDATE THIS LATER !!!

    //---------------------------------------------------------------------------

    public TextBox textBox;

    public GameObject[] choiceButtons = new GameObject[4];

    public int answer;

    private TextLine currentTextLine;



    // Imports choices from TextBox.
    public void ImportChoices(TextLine textLine)
    {
        int index = 0;



        // This is set for the Answer() function to use.
        currentTextLine = textLine;



        // Run through each button and display if text is found for it.
        foreach (GameObject button in choiceButtons)
        {
            switch (index)
            {
                case 0:

                    if (textLine.choice1 != "")
                    {
                        button.GetComponentInChildren<TextMeshProUGUI>().text = textLine.choice1;

                        button.SetActive(true);

                        break;
                    }

                    break;

                case 1:

                    if (textLine.choice2 != "")
                    {
                        button.GetComponentInChildren<TextMeshProUGUI>().text = textLine.choice2;

                        button.SetActive(true);

                        break;
                    }

                    break;

                case 2:

                    if (textLine.choice3 != "")
                    {
                        button.GetComponentInChildren<TextMeshProUGUI>().text = textLine.choice3;

                        button.SetActive(true);

                        break;
                    }

                    break;

                case 3:

                    if (textLine.choice4 != "")
                    {
                        button.GetComponentInChildren<TextMeshProUGUI>().text = textLine.choice4;

                        button.SetActive(true);

                        break;
                    }
                    
                    break;
            }

            index += 1;
        }
    }



    // Answers the question by activating the correct object and setting "isFinished = true" in TextBox.
    public void Answer(int answerNumber)
    {
        switch (answerNumber)
        {
            case 1:

                if (GameObject.Find(currentTextLine.choiceObj1) != null)
                {
                    if (GameObject.Find(currentTextLine.choiceObj1).GetComponent<Activatable>() != null)
                    {
                        GameObject.Find(currentTextLine.choiceObj1).GetComponent<Activatable>().activated = true;
                    }
                }

                ResetChoices();

                textBox.isAnswered = true;

                break;

            case 2:

                if (GameObject.Find(currentTextLine.choiceObj2) != null)
                {
                    if (GameObject.Find(currentTextLine.choiceObj2).GetComponent<Activatable>() != null)
                    {
                        GameObject.Find(currentTextLine.choiceObj2).GetComponent<Activatable>().activated = true;
                    }
                }

                ResetChoices();

                textBox.isAnswered = true;

                break;

            case 3:

                if (GameObject.Find(currentTextLine.choiceObj3) != null)
                {
                    if (GameObject.Find(currentTextLine.choiceObj3).GetComponent<Activatable>() != null)
                    {
                        GameObject.Find(currentTextLine.choiceObj3).GetComponent<Activatable>().activated = true;
                    }
                }

                ResetChoices();

                textBox.isAnswered = true;

                break;

            case 4:

                if (GameObject.Find(currentTextLine.choiceObj4) != null)
                {
                    if (GameObject.Find(currentTextLine.choiceObj4).GetComponent<Activatable>() != null)
                    {
                        GameObject.Find(currentTextLine.choiceObj4).GetComponent<Activatable>().activated = true;
                    }
                }

                ResetChoices();

                textBox.isAnswered = true;

                break;
        }
    }



    // Resets choice text and answer.
    public void ResetChoices()
    {
        foreach (GameObject button in choiceButtons)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "";

            button.SetActive(false);
        }

        answer = 0;
    }
}
