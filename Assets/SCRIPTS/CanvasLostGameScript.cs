using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLostGameScript : MonoBehaviour
{
    public Canvas canvasLost;
    public Canvas canvasUpgrade;

    public void UpgradeButton()
    {
        Debug.Log("UpgradeButton script");
        canvasLost.enabled = false;
        canvasUpgrade.enabled = true;

    }
}
