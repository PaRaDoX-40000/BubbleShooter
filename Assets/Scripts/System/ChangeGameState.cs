using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeGameState : MonoBehaviour
{
    [SerializeField] private UnityEvent StartPlayEvent;
    [SerializeField] private UnityEvent StopPlayEvent;

    public void StartPlay()
    {
        StartPlayEvent?.Invoke();
    }

    public void StopPlay()
    {
        StopPlayEvent?.Invoke();
    }

}
