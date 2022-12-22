using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject _towerToBuild;

    public static BuildManager _instance;
    public GameObject _standartTower;
    public GameObject _nextTower;

    private void Awake()
    {
        _instance = this;
    }

    public GameObject GetTowerToBuild()
    {
        return _towerToBuild;
    }

    public void SetTowerToBuild(GameObject curentTower)
    {
        _towerToBuild = curentTower;
    }

    
}
