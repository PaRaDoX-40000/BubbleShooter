using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PauseMenuUI _pauseMenuUI;
    [SerializeField] private ChangeGameState _changeGameState;

    private void Start()
    {
        _pauseMenuUI.SetButtons(Continue, BackToMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartPause();
        }
    }

    private void StartPause()
    {
        Time.timeScale = 0;
        _pauseMenuUI.gameObject.SetActive(true);
    }

    private void Continue()
    {
        Time.timeScale = 1;
        _pauseMenuUI.gameObject.SetActive(false);
    }

    private void BackToMenu()
    {
        Time.timeScale = 1;
        _pauseMenuUI.gameObject.SetActive(false);
        _changeGameState.StopPlay();
    }

}


