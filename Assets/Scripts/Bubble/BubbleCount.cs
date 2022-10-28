using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BubbleCount
{
    [SerializeField] Bubble _bubblePrfab;
    [SerializeField] int _count;

    public Bubble Bubble => _bubblePrfab;
    public int Count => _count; 
}
