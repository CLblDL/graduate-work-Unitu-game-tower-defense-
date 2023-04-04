using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI _upText;

    private Node _curentNode;
    
    public void SetNode(Node node)
    {
        _curentNode = node;

        transform.position = _curentNode.GetBuildPosition();
        _upText.text = _curentNode._curentTowerProject._towerUpCost.ToString();

        UI.SetActive(true);
    }
    
    public void HideTowerUI()
    {
        UI.SetActive(false);
    }

    public void Up()
    {
        _curentNode.UpTower();
        HideTowerUI();
    }
}
