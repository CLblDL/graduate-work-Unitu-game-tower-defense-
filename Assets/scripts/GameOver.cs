using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartLevel(int numberScene)
    {
        SceneManager.LoadScene(numberScene);

        Time.timeScale = 1;
    }   
}
