using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject _towerToBuild;

    public static BuildManager _instance;
    public GameObject _standartTower;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _towerToBuild = _standartTower;
    }

    public GameObject GetTowerToBuild()
    {
        return _towerToBuild;
    }
}
