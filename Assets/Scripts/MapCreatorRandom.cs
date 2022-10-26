using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreatorRandom : MapCreator
{
    [SerializeField] private int _height;
    [SerializeField] private int _length;



    public override int[,] CreateMap()
    {
        int[,] map = new int[_height, _length];
        for (int i = 0; i < map.GetUpperBound(0); i++)
        {           
            for (int j = 0; j < map.GetUpperBound(1); j++)
            {
                map[i,j] = Random.Range(0, 4);
            }
        }
        return map;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
