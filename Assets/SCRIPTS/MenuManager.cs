using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int selectedStage=0;
    public void selectaredinButon(int x)
    {

        selectedStage = x;
        Debug.Log(selectedStage.ToString());
    }
    public void playButton()
    {
        if (selectedStage == 1)
        {
            // SceneManager.LoadScene("Stage1");
            SceneManager.LoadScene("Level1");
        }

        
    }
   
}
