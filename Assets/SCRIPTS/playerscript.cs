using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerscript : MonoBehaviour
{
    public Rigidbody2D rb;
    private float vitezaMiscare;
    private  float vitezaSaritura;
    private  float gravityScale;
    public AudioSource jumpsound;
    public AudioClip enemyHit;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    private float timeOnPlatform=0;
    private SpriteRenderer spriteRenderer;
    public CharacterDatabase characterDB;
    public ParticleSystem dustPlatform;
    bool inAer = false;
    public int maxJumps;
    private int remainingJumps;
    public Button dashButtonButton;

    [Header("Dash")]
    private bool canDash = true;
    public bool isDashing = false;
    [SerializeField] private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    [Header("Bounce Back")]
    private bool isBouncingBack = false;

    void Start()
    {
        TrailRenderer tr = GetComponent<TrailRenderer>();
        Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
        tr.material.color = character.colorSupererou;
        maxJumps++;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        jumpsound = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetString("numeSupererou", spriteRenderer.sprite.ToString());
        Debug.Log(PlayerPrefs.GetString("numeSupererou"));
        setAbilities();
        corectSprite();
        remainingJumps = maxJumps;
        
    }

    void Update()
    {

        if (isDashing)
        {
            return;

        }
        if (isBouncingBack)
            return;
        PlayerPrefs.SetFloat("timeOnPlatform", timeOnPlatform);
        rb.velocity = new Vector2(vitezaMiscare, rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (onGround)
        {
            ///RESETJUMPS
            remainingJumps = maxJumps;
            timeOnPlatform += Time.deltaTime;
            ///ATERIZARE
            if (inAer == true)
            {
                CreateDustPlatform();
            }
            inAer = false;
        }
        if (!onGround)
            inAer = true;

        ///JUMP
      
        if (remainingJumps != 0)
        {
            bool jumped = false;
            if (Input.GetMouseButtonDown(0))
            {

                rb.velocity = new Vector2(vitezaMiscare, vitezaSaritura);
                if (Time.timeScale != 0)
                {
                    jumpsound.Play();
                
                }
                
                jumped = true;
            }
        
        
            if (Input.GetMouseButtonUp(0) && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
                jumped = true;
            }
            if(jumped==true)
            remainingJumps--;
        }
        
        
       // Debug.Log(remainingJumps + " ");
    }
    public void corectSprite()
    {
        Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
        spriteRenderer.sprite = character.spriteSupererou;

    }
    public void setAbilities()
    {
        Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
        vitezaSaritura = character.jumpValue;
        vitezaMiscare = character.speedValue;
        gravityScale = character.gravityValue;
        rb.gravityScale = gravityScale;
    }
    void CreateDustPlatform()
    {
        dustPlatform.Play();
    }
    /// DASH
    public IEnumerator Dash()
    {
        Debug.Log("EnteredDASH");
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x * dashingPower, 0f);
        float originalGravity = rb.gravityScale;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        dashButtonButton.interactable = false;
        yield return new WaitForSeconds(dashingCooldown);
        dashButtonButton.interactable = true;
        canDash= true;
        
    }
    public void dashButton()
    {
        
        if (canDash == true)
        {
            StartCoroutine(Dash());
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character character = characterDB.GetCharacter(PlayerPrefs.GetInt("selectedIndex"));
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            AudioSource.PlayClipAtPoint(enemyHit,this.gameObject.transform.position);
                    
        }
    }
    public void StartBouncing()
    {
        StartCoroutine(BounceBack());
    }
    public IEnumerator BounceBack()
    {
        Debug.Log("BounceBack");
        isBouncingBack = true;
        rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        yield return new WaitForSeconds(1);
       ///rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        isBouncingBack = false;
    }

}
