using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color _selectNideColor;
    public Color _selectNoClouseNideColor;

    private GameObject _curentTower;
    private Renderer _rend;
    private Color _satrtColor;
    private Vector3 _offsetPosition = new Vector3(0f, 0.5f, 0f);

    private void Awake()
    {
        _rend = GetComponent<Renderer>();
        _satrtColor = _rend.material.color;
    }

    private void OnMouseDown()
    {
        if(_curentTower != null)
        {
            Debug.Log("Клетка занята");
            return;
        }

        GameObject towerToBuild = BuildManager._instance.GetTowerToBuild();
        _curentTower = Instantiate(towerToBuild, transform.position + _offsetPosition, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if(_curentTower == null)
            _rend.material.color = _selectNideColor;
        else
            _rend.material.color = _selectNoClouseNideColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _satrtColor;
    }
}
