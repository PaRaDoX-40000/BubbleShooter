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
        _mapBubbles = new Bubble[_map.GetUpperBound(0)+1, _map.GetUpperBound(1)+1];
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
                        float x = (j + offset) * bubble.transform.localScale.x-(_map.GetUpperBound(1)* bubble.transform.localScale.x/2);
                        float y = (-i * bubble.transform.localScale.y) - bubble.transform.localScale.y;


                        Vector2 position = new Vector2(x, y);
                        bubble.transform.localPosition = position;
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

    //public List<Bubble> GetNearBubbles(int _colorNumber,Bubble bubble)
    //{
        
    //}

}
