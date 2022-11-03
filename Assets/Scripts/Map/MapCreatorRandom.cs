using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map Creator Random", menuName = "Map Creator/Random", order = 100)]
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
}
