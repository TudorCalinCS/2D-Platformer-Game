using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerEnter2D()
    {
        gameManager.TriggerEnd();
    }
}
