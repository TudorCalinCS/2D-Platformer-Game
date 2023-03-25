using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasWinScript : MonoBehaviour
{
    //public Canvas CanvasGameplay;
    public Canvas CanvasWin;
    public Canvas CanvasUpgrade;
    public void buttonUpgrade()
    {

        CanvasWin.enabled = false;
        CanvasUpgrade.enabled = true;

    }

}
