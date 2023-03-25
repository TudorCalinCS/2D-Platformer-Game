using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPowerPlayerScript : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("green entered Col");
            gameManager.EnableCanvasPower();
            Destroy(this.gameObject);
        }
    }
}
