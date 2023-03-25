using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameManager gameManager;

    public void OnTriggerEnter2D()
    {
        gameManager.WinEnd();
    }
}
