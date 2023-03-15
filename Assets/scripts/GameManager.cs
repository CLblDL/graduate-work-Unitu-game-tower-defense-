using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _gameOverUI;

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
}
