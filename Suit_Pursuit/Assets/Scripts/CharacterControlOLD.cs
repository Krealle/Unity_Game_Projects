using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterControlOLD: MonoBehaviour 
{
    public float maxSpeed = 10f;

    Animator anim;
    private bool boostUsed = false;
    public bool jumpboost = false;
    private bool speedboost = false;
    bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 400f;
    public float TimerCooldown = 0f;
    private float speedTimer = 0f;
    private float jumpTimer = 0f;
    public Slider speedboostSlider;
    public Slider jumpboostSlider;
    public Image speedFill;
    public Image speedFill2;
    public Image jumpFill;
    public Image jumpFill2;
    private float timerUI;
    private bool onCD = false;
    public Text score;
    private float scoreTimerRnd;
    private float distance = 0;
    public GameObject distanceBlock;
    public AudioClip jumpSound;
    public AudioClip jumpBoostSound;
    public AudioClip speedBoostSound;
    private AudioSource audioSource;

	void Start ()   
    {
        anim = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        // Score Caclc
        distance = Vector2.Distance(transform.position, distanceBlock.transform.position);
        scoreTimerRnd = Mathf.Round(distance * 1) / 1;
        score.text = "Score: " + scoreTimerRnd;

        if (boostUsed == true)
        {
            TimerCooldown += Time.deltaTime;

            if (TimerCooldown >= 5) 
            {
                if (onCD == false) 
                {
                    speedboostSlider.value = 5;
                    jumpFill.color = Color.white;
                    jumpFill2.color = Color.red;
                    speedFill.color = Color.white;
                    speedFill2.color = Color.red;
                    jumpboostSlider.value = 5;
                    onCD = true;
                }
                speedboostSlider.value -= Time.deltaTime / 2;
                jumpboostSlider.value -= Time.deltaTime / 2;
            }

            if (TimerCooldown >= 15) 
            {
                jumpFill.color = Color.white;
                speedFill.color = Color.white;
                boostUsed = false;
                onCD = false;
                TimerCooldown = 0;
            }
        }

        if (boostUsed == false && Input.GetKeyDown(KeyCode.W))
           {
               audioSource.clip = jumpBoostSound;
               audioSource.pitch = Random.Range(0.9f, 1.1f);
               audioSource.Play();
               jumpForce = 550f;
               speedFill.color = Color.red;
               jumpFill2.color = Color.blue;
               jumpboost = true;
               boostUsed = true;
           }

        if (jumpboost == true)
            {
                jumpTimer += Time.deltaTime;
                jumpboostSlider.value = jumpTimer;

                if (jumpTimer >= 5) {
                    jumpForce = 400f;
                    jumpTimer = 0f;
                    jumpboost = false;
                }
            }
        
            
        if (speedboost == true)
            {
                speedTimer += Time.deltaTime;
                speedboostSlider.value = speedTimer;

                if (speedTimer >= 5)
                {
                    maxSpeed = 10f;
                    speedTimer = 0f;
                    speedboost = false;
                }

            }
       if (boostUsed == false && Input.GetKeyDown(KeyCode.Q))
            {
                audioSource.clip = speedBoostSound;
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.Play();
                maxSpeed = 15f;
                jumpFill.color = Color.red;
                speedFill2.color = Color.blue;
                speedboost = true;
                boostUsed = true;
            }
       if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.clip = jumpSound;
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.Play();
                anim.SetBool("Ground", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }
    }
	void FixedUpdate () 
    {
        



        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

       GetComponent<Rigidbody2D>().velocity = new Vector2(1 * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
}
