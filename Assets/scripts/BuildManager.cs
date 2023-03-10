using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private ToweProject _towerToBuild;

    public static BuildManager _instance;

    public bool CanBuild { get { return _towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.HaveMoneyOnThisTower(_towerToBuild._towerCost); } }

    private void Awake()
    {
        _instance = this;
    }

    public void BuildTowerOn(Node node)
    {
        if(!HasMoney)
        {
            Debug.Log("Недостаточно денег");
            return;
        }

        PlayerStats.BuyTower(_towerToBuild._towerCost);

        GameObject tower = Instantiate(_towerToBuild._towerPrefab, node.GetBuildPosition(), Quaternion.identity);
        node._curentTower = tower;

        Debug.Log("Осталось денег" + PlayerStats.ShowMoneyNow());
    }

    public void SelectTowerToBuild(ToweProject selectedProject)
    {
        _towerToBuild = selectedProject;
    }
}
