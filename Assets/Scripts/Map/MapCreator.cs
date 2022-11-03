using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapCreator : ScriptableObject
{
   abstract public int[,] CreateMap();
}