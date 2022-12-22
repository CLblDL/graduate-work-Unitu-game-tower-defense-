using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color _selectNideColor;
    public Color _selectNoClouseNideColor;

    private GameObject _curentTower;
    private Renderer _rend;
    private Color _satrtColor;
    private Vector3 _offsetPosition = new Vector3(0f, 0.5f, 0f);
    private BuildManager _buildManager;

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

        if (_buildManager.GetTowerToBuild() == null)
        {
            return;
        }

        if(_curentTower != null)
        {
            Debug.Log("Клетка занята");
            return;
        }

        GameObject towerToBuild = _buildManager.GetTowerToBuild();
        _curentTower = Instantiate(towerToBuild, transform.position + _offsetPosition, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_buildManager.GetTowerToBuild() == null)
        {
            return;
        }

        if (_curentTower == null)
            _rend.material.color = _selectNideColor;
        else
            _rend.material.color = _selectNoClouseNideColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _satrtColor;
    }
}
