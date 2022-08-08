using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text/TextObject")]

public class TextObject : ScriptableObject
{

    public List<string> textData;

    [Rename("Enable Choice")]
    public bool hasChoice;

    [Space(10)]

    [Header("Choice Options")]

    [Space(10)]

    [Rename("Line with choice:")]
    public int line = -1;

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

    [Rename("Choice 1 - Object to activate:")]
    public GameObject choiceObj1;

    [Space(10)]

    [Rename("Choice 2 - Object to activate:")]
    public GameObject choiceObj2;

    [Space(10)]

    [Rename("Choice 3 - Object to activate:")]
    public GameObject choiceObj3;

    [Space(10)]

    [Rename("Choice 4 - Object to activate:")]
    public GameObject choiceObj4;

}
