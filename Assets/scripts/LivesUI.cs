using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public Text _lives;
    void Update()
    {
        _lives.text = $" Lives { PlayerStats.ShowLivesNow()}";
    }
}
