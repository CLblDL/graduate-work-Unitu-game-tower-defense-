using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int _startMoney = 400;

    void Start()
    {
        Money = _startMoney;
    }
}
