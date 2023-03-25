using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameObject : MonoBehaviour
{
    [SerializeField] private EnemyScript enemyScript;
    [SerializeField] private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.killed == true)
        {
            enemyScript.killed = false;
            particleSystem.Play();
        }
    }
}
