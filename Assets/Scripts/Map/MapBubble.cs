using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBubble : MonoBehaviour
{
    [SerializeField] private BubblePool _bubblePool;
    [SerializeField] private MapCreator _mapCreator;
    private int[,] _map;
    private Bubble[,] _mapBubbles;

    void Start()
    {
        CreateMap();
    }



    public void SetMapCreator(MapCreator mapCreator)
    {
        _mapCreator = mapCreator;
    }

    private void CreateMap()
    {
        _map = _mapCreator.CreateMap();
        _mapBubbles = new Bubble[_map.GetUpperBound(0)+1, _map.GetUpperBound(1)+4];
        for (int i=0;i<= _map.GetUpperBound(0); i++)
        {
            int horizontalQuantity = _map.GetUpperBound(1);
            

            float offset = 0;
            if (i % 2 == 1)
            {
                horizontalQuantity = _map.GetUpperBound(1)-1;
                offset = 0.5f;
            }
            else
            {
                horizontalQuantity = _map.GetUpperBound(1);
                offset = 0;
            }
            for (int j = 0; j <= horizontalQuantity; j++)
            {
                if (_map[i, j] != 0)
                {
                    if (_bubblePool.TryGetBubble(out Bubble bubble, _map[i, j]) == true)
                    {
                        bubble.gameObject.SetActive(true);
                        bubble.Move(i, j, _map.GetUpperBound(1), offset);
                       
                        _mapBubbles[i, j] = bubble;
                    }
                    else
                    {
                        _mapBubbles[i, j] = null;
                    }
                }
            }
        }
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
                if (x>=0 && x <= _mapBubbles.GetUpperBound(0))
                {
                    int y = (int)(_position.y + offsetCoordinatesY[i]);
                    if (y >= 0 && y <= _mapBubbles.GetUpperBound(1))
                    {
                        if(_mapBubbles[x, y] != null)
                        {
                            if(result.Contains(_mapBubbles[x, y]) == false)
                            {
                                if (bubble.ColorNumber == _mapBubbles[x, y].ColorNumber)
                                {
                                    if(needCheck.Contains(_mapBubbles[x, y]) == false)
                                    {
                                        needCheck.Add(_mapBubbles[x, y]);
                                    }
                                    
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

}
