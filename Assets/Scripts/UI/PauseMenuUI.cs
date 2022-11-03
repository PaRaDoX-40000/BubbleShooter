using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private Button _buttonBack;

    public void SetButtons(UnityAction continueAction, UnityAction backAction)
    {
        _buttonContinue.onClick.AddListener(continueAction);
        _buttonBack.onClick.AddListener(backAction);

    }
}
