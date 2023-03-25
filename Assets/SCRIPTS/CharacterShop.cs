using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterShop : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public int selectedCharacterIndex;
    private Color desiredColor;


    [Header("List of characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] public Text characterName;
    [SerializeField] public Image characterSplash;
    [SerializeField] public GameObject characterImageObject;
    //[SerializeField] private Image backgroundColor;
    [SerializeField] public Text characterValue;
    [SerializeField] public GameObject butonSelect;
    [SerializeField] public TextMeshProUGUI butonBuyText;
    [SerializeField] public Text requiredLevelText;
    [SerializeField] public Text requiredLevelValueText;
    public Button buttonBuy;



    /**
    [Header("Sounds")]
    [SerializeField] private AudioClip arrowClickSFX;
    [SerializeField] private AudioClip characterSelectMusic;
    */
    private void Start()
    {
        UpdateCharacterSelectioUI();
       
    }

    public void LeftArrow()
    {
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
            selectedCharacterIndex = characterList.Count - 1;

        UpdateCharacterSelectioUI();


    }

    public void RightArrow()
    {
        selectedCharacterIndex++;
        if (selectedCharacterIndex == characterList.Count)
            selectedCharacterIndex = 0;

        UpdateCharacterSelectioUI();

    }
   
    public void UpdateCharacterSelectioUI()
    {
        int gameindex = characterList[selectedCharacterIndex].gameIndex;
        Character character = characterDB.GetCharacter(gameindex);
  
            if (character.unlocked == true)///OWNED
            {
            buttonBuy.interactable = false;
            characterValue.text = null;
            requiredLevelText.text = null;
            requiredLevelValueText.text = null;
            butonSelect.SetActive(true);
            butonBuyText.text = "Owned";
           
            }
            else///NOT REQUIRED LEVEL
            if (PlayerPrefs.GetInt("playerLevel") < characterList[selectedCharacterIndex].requiredLevel)
            {
                butonSelect.SetActive(false);
                requiredLevelValueText.text = characterList[selectedCharacterIndex].requiredLevel.ToString();
                requiredLevelText.text = "You need level";

            }
            else///GOOD TO BUY
            {
            buttonBuy.interactable = true ;
            butonSelect.SetActive(true);
                requiredLevelText.text = null;
                requiredLevelValueText.text = null;
                butonBuyText.text = "Buy";
                
            }
        characterValue.text = characterList[selectedCharacterIndex].valuareCharacter;
        characterImageObject.SetActive(true);
        desiredColor = characterList[selectedCharacterIndex].characterColor;
        characterSplash.sprite = characterList[selectedCharacterIndex].splash;
        characterName.text = characterList[selectedCharacterIndex].characterName;
        characterName.color = desiredColor;
          
        
    }
    [System.Serializable]
    public class CharacterSelectObject
    {

        public Sprite splash;
        public string characterName;
        public Color characterColor;
        public string valuareCharacter;
        public int gameIndex;
        public int requiredLevel;

    }

    public void BuyButton()
    {
        // Debug.Log()
        int gameindex = characterList[selectedCharacterIndex].gameIndex;
        Character character = characterDB.GetCharacter(gameindex);
        UpdateCharacter(gameindex);
        Debug.Log(" " + gameindex);
        character.unlocked = true;
        butonBuyText.text = "Owned";


    }
    private void UpdateCharacter(int indexCharacter)
    {
        Debug.Log(characterDB);
        Character character = characterDB.GetCharacter(indexCharacter);
        PlayerPrefs.SetFloat("amountGravity", character.gravityValue);
        PlayerPrefs.SetFloat("amountSpeed", character.speedValue);
        PlayerPrefs.SetFloat("amountJump", character.jumpValue);
        PlayerPrefs.SetInt("selectedIndex", indexCharacter);

    }

    

 
    }





    

    
    




