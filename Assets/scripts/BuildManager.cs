using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private ToweProject _towerToBuild;
    private Node _selectedNode;

    public static BuildManager _instance;
    public TowerUI towerUI;

    public bool CanBuild { get { return _towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.HaveMoneyOnThisTower(_towerToBuild._towerCost); } }
    public ToweProject GetToweProject {get { return _towerToBuild; } }

    private void Awake()
    {
        _instance = this;
    }

    /*public void BuildTowerOn(Node node)
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
    }*/

    public void SelectNode(Node node)
    {
        if(_selectedNode == node)
        {
            DeselectNode();
            return;
        }

        _selectedNode = node;
        _towerToBuild = null;

        towerUI.SetNode(node);
    }

    public void SelectTowerToBuild(ToweProject selectedProject)
    {
        _towerToBuild = selectedProject;
        DeselectNode();
    }

    private void DeselectNode()
    {
        _selectedNode = null;

        towerUI.HideTowerUI();
    }
}
