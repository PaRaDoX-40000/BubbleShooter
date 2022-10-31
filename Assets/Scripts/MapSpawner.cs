using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] private MapCreator _mapCreator;
    [SerializeField] private BubblePool _bubblePool;
    [SerializeField] private Bubble _bubbleInvisiblePrefab;
    private int[,] _map;

   

    public void SetMapCreator(MapCreator mapCreator)
    {
        _mapCreator = mapCreator;
    }

    private void SpavnBubbleInvisible(int MaxLineLength)
    {
        for (int i = 0; i <= MaxLineLength; i++)
        {
            Bubble bubble = Instantiate(_bubbleInvisiblePrefab,transform);
            bubble.gameObject.SetActive(true);
            bubble.Move(-1, i, _map.GetUpperBound(1));
        }
    }


    public Bubble[,] CreateMap()
    {
        _map = _mapCreator.CreateMap();
        SpavnBubbleInvisible(_map.GetUpperBound(1)-1);
        Bubble[,] mapBubbles = new Bubble[_map.GetUpperBound(0) + 5, _map.GetUpperBound(1)+1];
        Debug.Log(_map.GetUpperBound(0));
        Debug.Log(_map.GetUpperBound(1));

        for (int y = 0; y <= _map.GetUpperBound(0); y++)
        {
            int horizontalQuantity = _map.GetUpperBound(1);
            if (y % 2 == 1)
            {
                horizontalQuantity = _map.GetUpperBound(1) - 1;

            }
            else
            {
                horizontalQuantity = _map.GetUpperBound(1);

            }
            for (int x = 0; x <= horizontalQuantity; x++)
            {
                if (_map[y, x] != 0)
                {
                    if (_bubblePool.TryGetBubble(out Bubble bubble, _map[y, x]) == true)
                    {
                        bubble.gameObject.SetActive(true);
                        bubble.Move(y, x, _map.GetUpperBound(1));

                        mapBubbles[y, x] = bubble;
                    }
                    else
                    {
                        mapBubbles[y, x] = null;
                    }
                }
            }
        }

        return mapBubbles;
    }
}
