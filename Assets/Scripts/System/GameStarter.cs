using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private MapSpawner _mapSpawner;
    [SerializeField] private BubbleGun _bubbleGun;
    [SerializeField] private ChangeGameState _ChangeGameState;

    public void StartGame(MapCreator mapCreator,BubbleSequenceGenerator bubbleSequenceGenerator)
    {
        _mapSpawner.SetMapCreator(mapCreator);
        _bubbleGun.SetBubbleSequenceGenerator(bubbleSequenceGenerator);
        _ChangeGameState.StartPlay();
    }
}
