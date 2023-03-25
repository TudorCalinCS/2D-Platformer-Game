using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   
    public static int Player_Lives=3;
    public int enemiesOnLevel;
    public int enemiesKills;
    public Text textPlayer_Lives;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Canvas canvasGameplay;
    public Canvas canvasWin;
    public Canvas canvasLostGame;
    public TextMeshProUGUI superheroNameText;
    public static int cointAmount=0;
    public Text CoinAmount;
    public Text coinTotal;
    public Text coinLevel;
    public Text timeOnPlatformText;
    public float levelDificulty;
    private int xpOnLevelEarned;
    public TextMeshProUGUI xpEarnedText;
    public TextMeshProUGUI numeSupererou;
    public GameObject butonDouble;
    LevelManager levelManager;
    public GameObject ObjectlevelManager;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI xpReqTot;
    public Canvas canvasPause;
    public playerscript playerscriptt;
    public CharacterDatabase characterdb;
    public TextMeshProUGUI valuePowerTextPlayer;
    public Canvas canvasPowerPlayer;
    public AudioClip congratsSound;
    public AudioSource audioSource;
    public GameObject playerGameObject;
    public TextMeshProUGUI enemiesText;

    
    public void Awake()
    {
        levelManager = ObjectlevelManager.GetComponent<LevelManager>();
    }
    public void Start()
    {
        //PlayerPrefs.DeleteAll();
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("doneDouble", 0);
        PlayerPrefs.SetInt("completedDouble", 0);
        if (PlayerPrefs.HasKey("totalXp") == false)
            PlayerPrefs.SetInt("totalXp", 0);
        Application.targetFrameRate = 300;

    }
    public void Update()
    {
       // Debug.Log(PlayerPrefs.GetInt("totalCoins").ToString() + " total bani");
        //Debug.Log(PlayerPrefs.GetInt("completedDouble").ToString());
        //Debug.Log(PlayerPrefs.GetInt("doneDouble").ToString());
        UIHealth();
        DisplayCoin();
        timeOnPlatformText.text = PlayerPrefs.GetFloat("timeOnPlatform").ToString();
        if(PlayerPrefs.GetInt("doneDouble") ==1)
        {
            butonDouble.SetActive(false);
        }
        if (canvasWin.enabled == true)
        {
            coinTotal.text = PlayerPrefs.GetInt("totalCoins").ToString();
        }
        if (!(Player_Lives > 0))
        {
            Time.timeScale = 0;
            canvasLostGame.enabled = true;
            canvasGameplay.enabled = false;
            Character character = characterdb.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            superheroNameText.text = character.name;
        }
        int powerPlayerValue;
        if (canvasPowerPlayer.enabled == true)
        {
            if (playerscriptt.isDashing == true)
            {
                Character character = characterdb.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
                powerPlayerValue = character.powerValue * 2;
            }
            else
            {
                Character character = characterdb.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
                powerPlayerValue = character.powerValue;
            }
            valuePowerTextPlayer.text = powerPlayerValue.ToString();
        }



    }
    
    public void TriggerEnd()
    {
        Debug.Log("GAMEOVER");
        ScadereLives();
        if(Player_Lives>0)
        restart();
        else
        {
            canvasLostGame.enabled = true;
            canvasGameplay.enabled = false;
        }
        
    }
    public void DisplayCoin()
    {
        CoinAmount.text = cointAmount.ToString();
    }
    public void CoinAdunat()
    {
        cointAmount += 1;
    }
    public void WinEnd()
    {
        Debug.Log("LEVEL WON");
        AudioSource.PlayClipAtPoint(congratsSound, playerGameObject.transform.position);
        Character character = characterdb.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
        numeSupererou.text = "Upgrade "+character.name;
        xpOnLevelEarned =((int)(PlayerPrefs.GetFloat("timeOnPlatform") * levelDificulty));
        if (enemiesKills > 0)
            xpOnLevelEarned += (int)(enemiesKills * levelDificulty * 5);
        PlayerPrefs.SetInt("totalXp", PlayerPrefs.GetInt("totalXp") + xpOnLevelEarned);
        levelManager.checkLevel();
        currentLevelText.text = "Level  "+PlayerPrefs.GetInt("playerLevel").ToString();
        xpReqTot.text = "Total Xp  " + PlayerPrefs.GetInt("totalXp").ToString() + "/" + PlayerPrefs.GetInt("requiredXp").ToString();
        xpEarnedText.text = xpOnLevelEarned.ToString()+"  XP EARNED";
        coinLevel.text = cointAmount.ToString();
        coinTotal.text = PlayerPrefs.GetInt("totalCoins").ToString();
        enemiesText.text = "ENEMIES KILLED  " + enemiesKills.ToString() + "/" + enemiesOnLevel.ToString();
        canvasGameplay.enabled = false;
        canvasWin.enabled = true;
        Time.timeScale = 0;

    }
    
    public void UIHealth()
    {
        if (Player_Lives == 3)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
        }
        else if (Player_Lives == 2)
        {
            heart3.enabled = false;
            heart1.enabled = true;
            heart2.enabled = true;
        }
        else if (Player_Lives == 1)
        {
            heart3.enabled = false;
            heart2.enabled = false;
            heart1.enabled = true;
        }
        else if (Player_Lives == 0)
        {
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
        }
    }
    public void ScadereLives()
    {
        Player_Lives -= 1;
        //textPlayer_Lives.text = Player_Lives.ToString();

    }
    public void restart()
    {
        PlayerPrefs.SetInt("doneDouble", 0);
        PlayerPrefs.SetInt("completedDouble", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        cointAmount = 0;
        playerscriptt.setAbilities();
        if (Player_Lives == 0)
            Player_Lives = 3;

    }
    public void doDoubleCoins()
    {
            Debug.Log("DODOUBLE");
            int newBalance = PlayerPrefs.GetInt("totalCoins") + cointAmount;
            PlayerPrefs.SetInt("totalCoins", newBalance);
            PlayerPrefs.SetInt("doneDouble", 1);
        
    }
    public void PauseMenu()
    {

        Time.timeScale = 0;
        canvasPause.enabled = true;
        canvasGameplay.enabled = false;
    }
    public void ContinueMenu()
    {
        Time.timeScale = 1;
        canvasPause.enabled = false;
        canvasGameplay.enabled = true;

    }
    public void EnableCanvasPower()
    {
        Debug.Log("CANVASENABLED");
        canvasPowerPlayer.enabled = true;

    }
    public void DisableCanvasPower()
    {
        canvasPowerPlayer.enabled = false;
        Debug.Log("CANVASdisable");
    }


}
