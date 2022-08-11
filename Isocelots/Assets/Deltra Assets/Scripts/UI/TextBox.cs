using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TextObjects;

public class TextBox : MonoBehaviour
{
    public List<TextLine> queuedText;

    public GameObject panel;
    public TextMeshProUGUI box;
    public FrameBox frameBox;

    public Choices choices;

    private float textSpeed = 0.1f;

    private bool isStart = true;

    private bool isFinished;

    public bool isAnswered = false;

    private float delay = 0;



    //Adds a TextObject to the queue.
    public void AddText(TextObject textObject)
    {
        foreach (TextLine textLine in textObject.textData)
        {
            queuedText.Add(textLine);
        }
    }



    //Increases typewritter speed on space hold.
    private void SpeedText()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            delay += Time.deltaTime;

            if (delay >= 0.2f)
            {
                textSpeed = 0.002f;
            }
        }
        else { delay = 0; textSpeed = 0.03f; }
    }



    //Displays a string of text on the textmeshpro component with a typewriter effect.
    private IEnumerator DisplayText(string displayText)
    {
        //Display frame if one is set.
        if (queuedText[0].frame != null)
        {
            frameBox.frameSprite = queuedText[0].frame;
        }

        //Typewriter effect.
        foreach (char c in displayText) {

            box.text += c;

            yield return new WaitForSeconds(textSpeed);
        }

        if (queuedText[0].hasChoice)
        {
            choices.ImportChoices(queuedText[0]);

            yield return null;
        }
        else
        {
            isFinished = true;

            yield return null;
        }
    }



    private void Update()
    {
        if (queuedText.Count != 0)
        {
            //Text is queued.

            PlayerState.Instance.busy = true;

            panel.SetActive(true);

            SpeedText();



            //Starts displaying the next line of text if the previous one is finished, and if there's more text to be displayed.
            if (Input.GetKeyDown(KeyCode.Space) && isFinished || isStart || isAnswered)
            {
                frameBox.frameSprite = null;

                isAnswered = false;

                if (!isStart)
                {
                    queuedText.RemoveAt(0);
                }

                if (queuedText.Count != 0)
                {
                    box.text = "";

                    isFinished = false;

                    isStart = false;

                    StartCoroutine(DisplayText(queuedText[0].text));
                }
            }
        }
        else
        {
            //There's no more text in the queue.

            isStart = true;

            panel.SetActive(false);

            PlayerState.Instance.busy = false;
        }
    }
}

