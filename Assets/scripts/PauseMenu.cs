using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject _pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchingPauseMenu();
        }
    }

    private void SwitchingPauseMenu()
    {
        _pauseMenuUI.SetActive(!_pauseMenuUI.activeSelf);

        if (_pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        SwitchingPauseMenu();
    }

    public void RetryScene()
    {
        SwitchingPauseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu(int indexScene)
    {
        SwitchingPauseMenu();
        SceneManager.LoadScene(indexScene);
    }
}
