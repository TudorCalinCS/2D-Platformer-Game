using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
       
    private int totalPlayerXP ;
    private int level=1;
    public int requiredXp;

    public void initializeVars()
    {
        if (PlayerPrefs.HasKey("playerLevel")==false)
        { PlayerPrefs.SetInt("playerLevel", level); }

       

        if (PlayerPrefs.HasKey("requiredXp")==false)
        { PlayerPrefs.SetInt("requiredXp", requiredXp); }
        /**
        Debug.Log("playerLevel " + PlayerPrefs.GetInt("playerLevel"));
        Debug.Log("totalXp " + PlayerPrefs.GetInt("totalXp"));
        Debug.Log("requiredXp " + PlayerPrefs.GetInt("requiredXp"));
        */


        totalPlayerXP = PlayerPrefs.GetInt("totalXp",0);
        level = PlayerPrefs.GetInt("playerLevel",1);
        requiredXp = PlayerPrefs.GetInt("requiredXp",0);

    }
    public void checkLevel()
    {
        initializeVars();
        Debug.Log("checkLEVEL FUNCTION");
        if (totalPlayerXP >= requiredXp)
        {
            while (totalPlayerXP >= requiredXp)
            {
                level += 1;
                totalPlayerXP -= requiredXp;
                requiredXp = (int)(requiredXp * 1.4);

            }
            
        }
        PlayerPrefs.SetInt("totalXp", totalPlayerXP);
        PlayerPrefs.SetInt("playerLevel", level);
        PlayerPrefs.SetInt("requiredXp", requiredXp);

    }




}

