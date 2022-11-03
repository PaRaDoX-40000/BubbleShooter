using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private ButtonWithHighlighting _buttonPlay;
    [SerializeField] private ButtonWithHighlighting _buttonRandomModMap;
    [SerializeField] private ButtonWithHighlighting _buttonPreCreatedModMap;
    [SerializeField] private ButtonWithHighlighting _buttonRandomModSequence;
    [SerializeField] private ButtonWithHighlighting _buttonPreCreatedModSequence;

    private List<ButtonWithHighlighting> buttons = new List<ButtonWithHighlighting>();

    private void Awake()
    {
        buttons.Add(_buttonPlay);
        buttons.Add(_buttonRandomModMap);
        buttons.Add(_buttonPreCreatedModMap);
        buttons.Add(_buttonRandomModSequence);
        buttons.Add(_buttonPreCreatedModSequence);
    }

    public void BttonAddListener(MenuButtons menuButtons,UnityAction unityAction)
    {
        buttons[(int)menuButtons].Button.onClick.AddListener(unityAction);
    }
    public void HighlightingSetActive(MenuButtons menuButtons)
    {
        buttons[(int)menuButtons].Highlighting.gameObject.SetActive(true);
        if(menuButtons == MenuButtons.PreCreatedModMap)
        {
            buttons[(int)MenuButtons.RandomModMap].Highlighting.gameObject.SetActive(false);
        }

        if (menuButtons == MenuButtons.RandomModMap)
        {
            buttons[(int)MenuButtons.PreCreatedModMap].Highlighting.gameObject.SetActive(false);
        }

        if (menuButtons == MenuButtons.PreCreatedModSequence)
        {
            buttons[(int)MenuButtons.RandomModSequence].Highlighting.gameObject.SetActive(false);
        }

        if (menuButtons == MenuButtons.RandomModSequence)
        {
            buttons[(int)MenuButtons.PreCreatedModSequence].Highlighting.gameObject.SetActive(false);
        }
    }

    public enum MenuButtons
    {
        Play=0,
        RandomModMap=1,
        PreCreatedModMap=2,
        RandomModSequence=3,
        PreCreatedModSequence=4
    }
}
