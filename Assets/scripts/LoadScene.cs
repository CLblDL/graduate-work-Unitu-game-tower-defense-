using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SceneFeder _sceneFeder;

    public void LoadSceneByIndex(int level)
    {
        _sceneFeder.FadeTo(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
