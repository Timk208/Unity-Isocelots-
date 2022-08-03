using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    public List<string> text;

    public TextMeshProUGUI box;

    private int lineNumber = 0;

    private float textSpeed = 0.1f;

    private bool isFinished = true;

    private float delay = 0;

    //Displays a string of text on the textmeshpro component with a typewriter effect.
    private IEnumerator DisplayText(string displayText)
    {
        //Typewriter effect.
        foreach (char c in displayText) {

            box.text += c;

            yield return new WaitForSeconds(textSpeed);
        }

        //Increments text line.
        lineNumber += 1;

        isFinished = true;

        yield return null;
    }

    private void Update()
    {
        //If Space is held down for more than 0.4 seconds, speed up the typewriter effect.
        if(Input.GetKey(KeyCode.Space))
        {
            delay += Time.deltaTime;

            if (delay >= 0.3f)
            {
                textSpeed = 0.005f;
            }
        }
        else { delay = 0; textSpeed = 0.05f; }

        //Auto-displays the first line of text without Space needing to be pressed. Could most likely be improved.
        if(lineNumber == 0 && isFinished)
        {
            box.text = "";

            isFinished = false;

            StartCoroutine(DisplayText(text[lineNumber]));
        }

        //Starts displaying the next line of text if the previous one is finished, and if there's more text to be displayed.
        if(Input.GetKeyDown(KeyCode.Space) && isFinished && lineNumber < text.Count)
        {
            box.text = "";

            isFinished = false;

            StartCoroutine(DisplayText(text[lineNumber]));
        }
    }
}
