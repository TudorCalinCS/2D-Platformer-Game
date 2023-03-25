using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public Text amountGravitytext;
    public Text amountJumptext;
    public Text amountSpeedtext;
    public Text amountPowertext;
    public int costGravity;
    public int costJump;
    public int costSpeed;
    public int costPower;
    public Text amountCostGravitytext;
    public Text amountCostJumptext;
    public Text amountCostSpeedtext;
    public Text amountCostPowertext;
    public Text totalCoins;
    public Canvas canvasWin;
    public Canvas canvasUpgrade;
    public CharacterDatabase characterDB;
  
    public void Update()
    {
        Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
        totalCoins.text = PlayerPrefs.GetInt("totalCoins").ToString();
        amountGravitytext.text = character.gravityValue.ToString();
        amountSpeedtext.text = character.speedValue.ToString();
        amountJumptext.text = character.jumpValue.ToString();
        amountPowertext.text = character.powerValue.ToString();
        amountCostGravitytext.text = costGravity.ToString();
        amountCostJumptext.text = costJump.ToString();
        amountCostSpeedtext.text = costSpeed.ToString();
        amountCostPowertext.text = costPower.ToString();

}
    public void PowerUpGravity()
    {
        if (costGravity <= PlayerPrefs.GetInt("totalCoins"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int balanta = PlayerPrefs.GetInt("totalCoins");
            balanta -= costGravity;
            PlayerPrefs.SetInt("totalCoins", balanta);
            character.gravityValue++;  
        }
        

    }
    public void PowerDownGravity()
    {
        if (costGravity <= PlayerPrefs.GetInt("totalCoins"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int balanta = PlayerPrefs.GetInt("totalCoins");
            balanta -= costGravity;
            PlayerPrefs.SetInt("totalCoins", balanta);
            character.gravityValue--;
        }
        
    }
    public void PowerUpSpeed()
    {
        if (costSpeed <= PlayerPrefs.GetInt("totalCoins"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int balanta = PlayerPrefs.GetInt("totalCoins");
            balanta = balanta - costSpeed;
            PlayerPrefs.SetInt("totalCoins", balanta);
            character.speedValue++;
        }

    }
    public void PowerDownSpeed()
    {
        if (costSpeed <= PlayerPrefs.GetInt("totalCoins"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int balanta = PlayerPrefs.GetInt("totalCoins");
            balanta = balanta - costSpeed;
            PlayerPrefs.SetInt("totalCoins", balanta);
            character.speedValue--;
        }
    }
    public void PowerUpJump()
    {
        if (costSpeed <= PlayerPrefs.GetInt("totalCoins"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int balanta = PlayerPrefs.GetInt("totalCoins");
            balanta = balanta - costJump;
            PlayerPrefs.SetInt("totalCoins", balanta);
            character.jumpValue++;
        }
    }
    public void PowerDownJump()
    {
        if (costSpeed <= PlayerPrefs.GetInt("totalCoins"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int balanta = PlayerPrefs.GetInt("totalCoins");
            balanta = balanta - costJump;
            PlayerPrefs.SetInt("totalCoins", balanta);
            character.jumpValue--;
        }
    }
    public void PowerUpPower()
    {
        if (costSpeed <= PlayerPrefs.GetInt("totalCoins"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int balanta = PlayerPrefs.GetInt("totalCoins");
            balanta = balanta - costPower;
            PlayerPrefs.SetInt("totalCoins", balanta);
            character.powerValue += 5;
        }
    }
    public void PowerDownPower()
    {
        if (costSpeed <= PlayerPrefs.GetInt("totalCoins"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int balanta = PlayerPrefs.GetInt("totalCoins");
            balanta = balanta - costPower;
            PlayerPrefs.SetInt("totalCoins", balanta);
            character.powerValue -= 5;
        }
    }
    public void backButton()
    {
        canvasUpgrade.enabled = false;
        canvasWin.enabled = true;
    }
   
    public void doResetPowers()
    {
        Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
        character.jumpValue = character.jumpInitialValue;
        character.gravityValue = character.gravityInitialValue;
        character.speedValue = character.speedInitialValue;
        character.powerValue = character.powerInitialValue;


    }
}
