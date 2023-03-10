using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    public ToweProject _standartTower;
    public ToweProject _nextTower;
    public ToweProject _laserTower;

    private void Start()
    {
        _buildManager = BuildManager._instance;
    }

    public void ByStandartTower()
    {
        _buildManager.SelectTowerToBuild(_standartTower);
    }

    public void ByNextTower()
    {
        _buildManager.SelectTowerToBuild(_nextTower);
    }

    public void ByLaserTower()
    {
        _buildManager.SelectTowerToBuild(_laserTower);
    }
}
