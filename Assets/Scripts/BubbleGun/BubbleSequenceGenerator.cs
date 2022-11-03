using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BubbleSequenceGenerator : ScriptableObject
{   
    abstract public Bubble NextBubble();
}
