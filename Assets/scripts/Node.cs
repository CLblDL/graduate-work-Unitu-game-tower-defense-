using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color _selectNideColor;
    public Color _selectNoClouseNideColor;
    [Header("Необязательно")]
    public GameObject _curentTower;
    public ToweProject _curentTowerProject;
    private Renderer _rend;
    private Color _satrtColor;
    private Vector3 _offsetPosition = new Vector3(0f, 0.5f, 0f);
    private BuildManager _buildManager;

    public Vector3 GetBuildPosition()
    {
        return transform.position + _offsetPosition;
    }

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _satrtColor = _rend.material.color;
        _buildManager = BuildManager._instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(_curentTower != null)
        {
            _buildManager.SelectNode(this);
            return;
        }

        if (!_buildManager.CanBuild)
        {
            return;
        }

        //_buildManager.BuildTowerOn(this);
        BuildTower(_buildManager.GetToweProject);
    }
    
    private void BuildTower(ToweProject towerToBuild)
    {
        if (!PlayerStats.HaveMoneyOnThisTower(towerToBuild._towerCost))
        {
            Debug.Log("Недостаточно денег");
            return;
        }

        PlayerStats.BuyTower(towerToBuild._towerCost);

        _curentTowerProject = towerToBuild;

        GameObject tower = Instantiate(towerToBuild._towerPrefab, GetBuildPosition(), Quaternion.identity);
        _curentTower = tower;

        Debug.Log("Осталось денег" + PlayerStats.ShowMoneyNow());
    }

    public void UpTower()
    {


        int towerUpCost = _curentTowerProject._towerUpCost;

        if (!PlayerStats.HaveMoneyOnThisTower(towerUpCost))
        {
            Debug.Log("Недостаточно денег");
            return;
        }

        PlayerStats.BuyTower(towerUpCost);

        Tower tower = _curentTower.GetComponent<Tower>();
        tower._fireRate *= 2;

        _curentTowerProject._towerUpCost *= 2;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.CanBuild)
        {
            return;
        }

        if (_buildManager.HasMoney && _curentTower == null)
        {
            _rend.material.color = _selectNideColor;
        }
        else
            _rend.material.color = _selectNoClouseNideColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _satrtColor;
    }
}
