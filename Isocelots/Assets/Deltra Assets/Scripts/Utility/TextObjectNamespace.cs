using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextObjects
{
    [System.Serializable]

    public class TextLine
    {
        [Tooltip("Text to display.")]
        [Rename("Text:")]
        public string text;

        [Space(10)]

        [Tooltip("Sprite to use for the frame (leave blank if none.)")]
        [Rename("Frame:")]
        public Sprite frame;

        [Space(10)]

        [Tooltip("Should this line of text include a choice?")]
        [Rename("Enable Choice:")]
        public bool hasChoice;

        [Space(10)]

        [Rename("Choice 1:")]
        public string choice1;

        [Space(10)]

        [Rename("Choice 2:")]
        public string choice2;

        [Space(10)]

        [Rename("Choice 3:")]
        public string choice3;

        [Space(10)]

        [Rename("Choice 4:")]
        public string choice4;

        [Space(10)]

        [Rename("Choice 1 - Name of object to activate:")]
        public string choiceObj1;

        [Space(10)]

        [Rename("Choice 2 - Name of object to activate:")]
        public string choiceObj2;

        [Space(10)]

        [Rename("Choice 3 - Name of object to activate:")]
        public string choiceObj3;

        [Space(10)]

        [Rename("Choice 4 - Name of object to activate:")]
        public string choiceObj4;
    }
}

