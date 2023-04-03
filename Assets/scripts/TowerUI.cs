using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    public GameObject UI;

    private Node _curentNode;
    
    public void SetNode(Node node)
    {
        _curentNode = node;

        transform.position = _curentNode.GetBuildPosition();

        UI.SetActive(true);
    }
    
    public void HideTowerUI()
    {
        UI.SetActive(false);
    }
}
