using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text _money;
    void Update()
    {
        _money.text = PlayerStats.ShowMoneyNow().ToString();
    }
}
