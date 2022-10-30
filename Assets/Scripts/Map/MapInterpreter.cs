using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapInterpreter : MonoBehaviour
{
    
    List<Vector2> directionVectors = new List<Vector2>()
    { new Vector2(1, 1),
      new Vector2(-1, 1),
      new Vector2(-1, 0),
      new Vector2(-1, -1),
      new Vector2(1, -1),
      new Vector2(1, 0)};

    int[] _offsetCoordinatesY = new int[] { -1, -1, 0, 1, 1, 0 };
    int[] _offsetCoordinatesEvenX = new int[] { 0, -1, -1, -1, 0, 1 };
    int[] _offsetCoordinatesNotEveX = new int[] { 1, 0, -1, 0, 1, 1 };



    public bool InterpretVectorIntoLocalCoordinates(Vector2 hitVector,int y, out Vector2 newVector)
    {
        try
        {
            Vector2 v = directionVectors.Find(q => q.x == hitVector.x && q.y == hitVector.y);
            int index = directionVectors.IndexOf(v);           
            int[] offsetCoordinatesX;
            
            if (y % 2 == 0)
            {
                offsetCoordinatesX = _offsetCoordinatesEvenX;
            }
            else
            {
                offsetCoordinatesX = _offsetCoordinatesNotEveX;
            }           
            newVector = new Vector2(offsetCoordinatesX[index], _offsetCoordinatesY[index]);            
            return true;
        }
        catch
        {
            newVector = Vector2.zero;
            Debug.LogError("Произошла ошибка в итерпритации кординат");
            return false;
        }
    }    
}
