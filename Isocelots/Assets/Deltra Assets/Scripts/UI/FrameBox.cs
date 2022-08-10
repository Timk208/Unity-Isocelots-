using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameBox : MonoBehaviour
{
    public Sprite frameSprite;

    public GameObject panel;

    public Image frame;

    private void Update()
    {
        //If a frame is given, display the panel and image.

        if (frameSprite != null)
        {
            panel.SetActive(true);

            frame.sprite = frameSprite;
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
