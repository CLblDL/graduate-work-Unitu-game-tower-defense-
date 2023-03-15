using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static int Money;
    public int _startMoney = 400;

    private static int Lives;
    public int _startLives = 20;

    public static GameManager _gameManager;

    void Start()
    {
        Money = _startMoney;
        Lives = _startLives;
    }

    public static void TakeAweyLives(int damageHp)
    {
        if(Lives >= damageHp)
        {
            Lives -= damageHp;
        }
        else
        {
            Lives = 0;
        }
        if(Lives == 0)
        {           
            _gameManager.LouseLevel(); 
        }
    }

    public static bool HaveMoneyOnThisTower(int towerCost)
    {
        if (Money >= towerCost)
            return true;
        else
            return false;
    }

    public static int ShowLivesNow()
    {
        return Lives;
    }

    public static int ShowMoneyNow()
    {
        return Money;
    }

    public static void BuyTower(int towerCost)
    {
        Money -= towerCost;
    }

    public static void IncreaseMoney(int countMoney)
    {
        Money += countMoney;
    }
}
