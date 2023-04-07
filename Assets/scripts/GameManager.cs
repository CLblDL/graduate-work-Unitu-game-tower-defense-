using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _gameOverUI;
    public int _currentLevel;
    public string _nameNextLevel;
    public SceneFeder _sceneFeder;

    private void Awake()
    {
        PlayerStats._gameManager = this;
    }

    public void LouseLevel()
    {
        Debug.Log("End game!");
        Time.timeScale = 0;
        _gameOverUI.SetActive(true);
    }

    public void LevelWin()
    {
        Debug.Log("LEVEL WON");

        int currentLevelComlete = PlayerPrefs.GetInt("levelReached");

        if(_currentLevel == currentLevelComlete)
        {
            PlayerPrefs.SetInt("levelReached", _currentLevel + 1);
        }

        Debug.Log($"{PlayerPrefs.GetInt("levelReached")}");
        _sceneFeder.FadeTo(_nameNextLevel);
        //необходимо проверять какой уровень пройден, нужно ли увеличивать последней уровень в PlayerPrefs выводить меню и запускать след урвоень.
    }
}
