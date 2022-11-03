using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Line 
{
    [SerializeField] private int[] _values;

    public int[] Values => _values;
}
