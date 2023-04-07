using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFeder _sceneFeder;

    public void RestartLevel(int numberScene)
    {
        _sceneFeder.FadeTo(numberScene);

        Time.timeScale = 1;
    }   
}
