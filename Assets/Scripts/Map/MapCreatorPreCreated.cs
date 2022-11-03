using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map Creator Pre Created", menuName = "Map Creator/Pre Created", order = 100)]
public class MapCreatorPreCreated : MapCreator
{
    [SerializeField] Line[] lines;

    public override int[,] CreateMap()
    {
        try
        {
            int[,] map = new int[lines.Length, lines[0].Values.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Values.Length; j++)
                {
                    map[i, j] = lines[i].Values[j];
                }
            }
            return map;
        }
        catch
        {
            Debug.LogError("Произошла ошибка в передаче заранее сгенерированной карты");
        }
        return null;
    }   
}
