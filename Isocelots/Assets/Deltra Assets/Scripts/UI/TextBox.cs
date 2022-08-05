using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    public List<string> queuedText;

    public GameObject panel;
    public TextMeshProUGUI box;

    private float textSpeed = 0.1f;

    private bool isStart = true;

    private bool isFinished;

    private float delay = 0;

    //Uses a TextObject to add lines of text to the queue.
    public void AddText(TextObject textObject)
    {
        foreach (string textLine in textObject.textData)
        {
            queuedText.Add(textLine);
        }
    }

    //Displays a string of text on the textmeshpro component with a typewriter effect.
    private IEnumerator DisplayText(string displayText)
    {
        //Typewriter effect.
        foreach (char c in displayText) {

            box.text += c;

            yield return new WaitForSeconds(textSpeed);
        }

        isFinished = true;

        yield return null;
    }

    private void Update()
    {
        if(queuedText.Count != 0)
        {
            //Text is queued.

            panel.SetActive(true);

            PlayerState.Instance.busy = true;

            //If Space is held down for more than 0.2 seconds, speed up the typewriter effect.
            if (Input.GetKey(KeyCode.Space))
            {
                delay += Time.deltaTime;

                if (delay >= 0.2f)
                {
                    textSpeed = 0.002f;
                }
            }
            else { delay = 0; textSpeed = 0.03f; }

            //Auto-displays the first line of text without Space needing to be pressed. Could most likely be improved.
            if (isStart)
            {
                isStart = false;

                box.text = "";

                isFinished = false;

                StartCoroutine(DisplayText(queuedText[0]));
            }

            //Starts displaying the next line of text if the previous one is finished, and if there's more text to be displayed.
            if (Input.GetKeyDown(KeyCode.Space) && isFinished)
            {
                queuedText.RemoveAt(0);

                if (queuedText.Count != 0)
                {
                    box.text = "";

                    isFinished = false;

                    StartCoroutine(DisplayText(queuedText[0]));
                }
            }
        }
        else
        {
            //No text is queued.

            isStart = true;

            panel.SetActive(false);

            PlayerState.Instance.busy = false;
        }
    }
}
