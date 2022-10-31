using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBubble : MonoBehaviour
{
    [SerializeField] private BubblePool _bubblePool;
    [SerializeField] private MapSpawner _mapSpawner;    
    [SerializeField] private MapInterpreter _mapInterpreter;   
    private Bubble[,] _mapBubbles;

    void Start()
    {
        _mapBubbles = _mapSpawner.CreateMap();
    }

    public bool TryAddbubble(Vector2 hitVector, Bubble bubbleSticking, int colorNumber, out Bubble bubbleResult)
    {
        bubbleResult = null;
        if (_mapInterpreter.InterpretVectorIntoLocalCoordinates(hitVector, (int)bubbleSticking.Position.y, out Vector2 position) == true)
        {
            int x = (int)(position.x + bubbleSticking.Position.x);
            int y = (int)(position.y + bubbleSticking.Position.y);           
            if (WithinArray(y, x) == false)
            {                
                return false;              
            }
            else
            {            
                if (_bubblePool.TryGetBubble(out Bubble bubbleObject, colorNumber) == true)
                {
                    bubbleObject.gameObject.SetActive(true);
                    bubbleObject.Move(y, x, _mapBubbles.GetUpperBound(1));
                    _mapBubbles[y, x] = bubbleObject;
                    bubbleResult = bubbleObject;
                }
                return true;
            }
        }
        return false;
    }
    private bool WithinArray(int y, int x)
    {
       
        if (y >= 0 && y <= _mapBubbles.GetUpperBound(0))
        {
          
            
            if (x >= 0 && x <= _mapBubbles.GetUpperBound(1))
            {
                return true;
            }
        }        
        return false;
    }



    

    public List<Bubble> GetNearBubbles(Bubble bubble)
    {
        int[] offsetCoordinatesX;
        int[] offsetCoordinatesY = new int[] { -1, -1, 0, 1, 1, 0 };


        List<Bubble> result = new List<Bubble>();
        List<Bubble> needCheck = new List<Bubble>();
        
        needCheck.Add(bubble);

        while (needCheck.Count > 0)
        {
            Vector2 _position = needCheck[0].Position;
            if (_position.y % 2 == 0)
            {
                offsetCoordinatesX = new int[] { 0, -1, -1, -1, 0, 1 };                
            }
            else
            {
                offsetCoordinatesX = new int[] { 1, 0, -1, 0, 1, 1 };                
            }

            for (int i=0;i< offsetCoordinatesX.Length; i++)
            {
                int x = (int)(_position.x + offsetCoordinatesX[i]);
                int y = (int)(_position.y + offsetCoordinatesY[i]);

                if (WithinArray(y, x))
                {
                    if (_mapBubbles[y, x] != null)
                    {
                        if (result.Contains(_mapBubbles[y, x]) == false)
                        {
                            if (bubble.ColorNumber == _mapBubbles[y, x].ColorNumber)
                            {
                                if (needCheck.Contains(_mapBubbles[y, x]) == false)
                                {
                                    needCheck.Add(_mapBubbles[y, x]);
                                }

                            }
                        }

                    }
                }
            }
            result.Add(needCheck[0]);
            needCheck.Remove(needCheck[0]);
        }
        if (result.Count > 2)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public void DestroyNearBubbles(Bubble bubble)
    {
        List<Bubble> bubbles = GetNearBubbles(bubble);
        if (bubbles != null)
        {
            foreach (Bubble bub in bubbles)
            {
                bub.gameObject.SetActive(false);
                _mapBubbles[(int)bub.Position.y, (int)bub.Position.x] = null;
            }
        }
    } 

}
