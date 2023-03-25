using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinScript : MonoBehaviour
{
    public GameManager gameManager;
   public AudioClip coinSound;
    public static int totalCoinAmount = 0;
    //public AudioSource audioSource;

     void Start()
    {
        totalCoinAmount=PlayerPrefs.GetInt("totalCoins");

    }

    void OnTriggerEnter2D()
    {
        
        totalCoinAmount += 1;
        PlayerPrefs.SetInt("totalCoins", totalCoinAmount);
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
        //audioSource.Play();
        gameManager.CoinAdunat();
        Destroy(gameObject);
       
    }
    /**
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            totalCoinAmount += 1;
            PlayerPrefs.SetInt("totalCoins", totalCoinAmount);
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            gameManager.CoinAdunat();
            Destroy(gameObject);
        }
    }
    */
}
