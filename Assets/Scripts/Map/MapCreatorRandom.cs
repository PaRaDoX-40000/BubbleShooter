using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreatorRandom : MapCreator
{
    [SerializeField] private int _length; 
     [SerializeField] private int _height;



    public override int[,] CreateMap()
    {
        
        int[,] map = new int[_height, _length];
        for (int i = 0; i <= map.GetUpperBound(0); i++)
        {
            
            for (int j = 0; j <= map.GetUpperBound(1); j++)
            {
                int t = Random.Range(0, 4);
                
                map[i, j] = t;
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
