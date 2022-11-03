using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BubbleCount
{
    [SerializeField] private Bubble _bubblePrfab;
    [SerializeField] private int _count;

    public Bubble Bubble => _bubblePrfab;
    public int Count => _count; 
}
