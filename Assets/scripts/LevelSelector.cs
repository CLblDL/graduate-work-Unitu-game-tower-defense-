using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    public SceneFeder _sceneFeder;

    private void Start()
    {
        BlockClouseLevel();
    }

    private void BlockClouseLevel()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = levelReached; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        _sceneFeder.FadeTo(levelIndex);
    }
}
