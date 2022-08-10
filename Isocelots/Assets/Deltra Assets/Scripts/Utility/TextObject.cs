using System.Collections.Generic;
using UnityEngine;
using TextObjects;

[CreateAssetMenu(menuName = "Text/TextObject")]

public class TextObject : ScriptableObject
{
    public List<TextLine> textData;
}
