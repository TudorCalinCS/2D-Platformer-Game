using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public int selectedCharacterIndex;
    private Color desiredColor;
    public string catcosta;
   
    [Header("List of characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] public Text characterName;
    [SerializeField] public Image characterSplash;
    [SerializeField] public GameObject characterImageObject;
    //[SerializeField] private Image backgroundColor;
    //[SerializeField] public Text characterValue;
    [SerializeField] public GameObject butonSelect;
    [Header("Lacat")]
    [SerializeField] public GameObject lacatImage;


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
        Character character = characterDB.GetCharacter(selectedCharacterIndex);
        if (character.unlocked == true) {


            lacatImage.SetActive(false);
            butonSelect.SetActive(true);
            characterImageObject.SetActive(true);

            desiredColor = characterList[selectedCharacterIndex].characterColor;
        characterSplash.sprite = characterList[selectedCharacterIndex].splash;
        characterName.text = characterList[selectedCharacterIndex].characterName;
        characterName.color = desiredColor;
        
        
        }
        else
        {
            lacatImage.SetActive(true);
            butonSelect.SetActive(false);
            desiredColor = Color.white;
            characterName.text = "???";
            characterName.color = desiredColor;
            characterImageObject.SetActive(false);

        }
       

    }
    [System.Serializable]
    public class CharacterSelectObject
    {

        public Sprite splash;
        public string characterName;
        public Color characterColor;
        //public string valuareCharacter;

    }

    public void SelectButton()
    {
        UpdateCharacter(selectedCharacterIndex);
        Debug.Log(" " + selectedCharacterIndex);
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





    

    
    




