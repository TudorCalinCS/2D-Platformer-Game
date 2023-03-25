using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private  float vitezaSaritura;
    public AudioSource enemyHit;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public CharacterDatabase characterDB;
    public ParticleSystem dustPlatform;
    bool inAer = false;
    public int requiredPowerToKill;
    public TextMeshProUGUI valuePowerText;
    public Canvas canvasPower;
    public playerscript player;
    public GameManager gameManager;
    public bool killed;
    




    void Start()
    {
        Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        enemyHit = GetComponent<AudioSource>();
        //player = GetComponent<playerscript>();
        valuePowerText.text = requiredPowerToKill.ToString(/*"0.00#"*/);
    }

    void Update()
    { 
       
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (onGround)
        {   ///ATERIZARE
            if (inAer == true)
            {
                CreateDustPlatform();
                rb.velocity = new Vector2(0, 3);
            }
            inAer = false;
        }
        if (!onGround)
            inAer = true;                    
    } 
    void CreateDustPlatform()
    {
        dustPlatform.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
            int charPowValue = character.powerValue;
            if (player.isDashing == true)
                charPowValue = charPowValue * 2;
            if (charPowValue >= requiredPowerToKill)
            {
                Destroy(this.gameObject);
                gameManager.enemiesKills++;
                killed = true;
            }
            else
            {
                player.StartBouncing();
                gameManager.ScadereLives();
            }
        }
    }

}
