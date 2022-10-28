using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapCreator : MonoBehaviour
{
   abstract public int[,] CreateMap();
}