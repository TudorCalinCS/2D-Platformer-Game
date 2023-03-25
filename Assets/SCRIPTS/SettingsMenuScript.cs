using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuScript : MonoBehaviour
{
    public Canvas canvasSetari;
    public void changeQuality(int indexQuality)
    {

        QualitySettings.SetQualityLevel(indexQuality);
    }
    public void closeCanvas()
    {

        canvasSetari.enabled = false;
    }
}
