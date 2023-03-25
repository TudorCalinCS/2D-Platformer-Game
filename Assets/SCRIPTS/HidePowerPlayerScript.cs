using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePowerPlayerScript : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("CANVASdisable");
            gameManager.DisableCanvasPower();
            Destroy(this.gameObject);
        }
    }
}
