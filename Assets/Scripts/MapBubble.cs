using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBubble : MonoBehaviour
{
    [SerializeField] private BubblePool _bubblePool;
    [SerializeField] private MapCreator _mapCreator;
    private int[,] _map;

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
        for(int i=0;i< _map.GetUpperBound(0); i++)
        {
            int x = 0;
            float offset = 0;
            if (i % 2 == 1)
            {
                x = _map.GetUpperBound(1) - 1;
                offset = 0.5f;
            }
            else
            {
                x = _map.GetUpperBound(1);
                offset = 0;
            }
            for (int j = 0; j < x; j++)
            {
                if (_map[i, j] != 0)
                {
                    if (_bubblePool.TryGetBubble(out Bubble bubble, _map[i, j]) == true)
                    {
                        bubble.gameObject.SetActive(true);
                        bubble.transform.localPosition = new Vector2(j + offset,-i);
                    }
                }
            }
        }

    }




    

    

    void Update()
    {
        
    }
}
