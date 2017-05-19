using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public float maxSpeed = 8f;

    Animator anim;
    private bool boostUsed = false;
    public bool jumpboost = false;
    private bool speedboost = false;
    bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 500;
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
    public bool roofed;
    public Transform roofCheck;
    private float slideTimer;
    private bool isJumping = false;
    public float jumpedTime;
    public float maxJumpTime = 3;
    private bool powerupUsed;
    public Text newHigh;
    private float newHighTimer;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        maxSpeed = 8f;
        powerupUsed = false;
        newHigh.enabled = false;
        newHighTimer = 0;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Powerup") {
            Destroy(coll.gameObject);
            powerupUsed = true;
        }
    }

    void StoreHighScore(float newHighscore) {
        int oldHighScore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighscore > oldHighScore) {
            PlayerPrefs.SetInt("highscore", (int)newHighscore);
        }
    }

    public void LoseGame() {
        Application.LoadLevel(2);
        StoreHighScore(scoreTimerRnd);
    }

    void Update()
    {
        anim.SetBool("Slide", Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S));

        // Score Caclc
        distance = Vector2.Distance(transform.position, distanceBlock.transform.position);
        scoreTimerRnd = Mathf.Round(distance * 1) / 1;
        score.text = "Score: " + scoreTimerRnd;
        if (scoreTimerRnd > PlayerPrefs.GetInt("highscore", 0)) {
            if (newHighTimer < 3) {
                newHigh.enabled = true;
                newHighTimer += Time.deltaTime;
            } else {
                newHigh.enabled = false;
            }
            
        }

        if (transform.position.y < -8) {
            LoseGame();
        }

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

            if (TimerCooldown >= 15 || powerupUsed && TimerCooldown >= 5)
            {
                jumpFill.color = Color.white;
                speedFill.color = Color.white;
                boostUsed = false;
                onCD = false;
                TimerCooldown = 0;
                maxSpeed = 8f;
                jumpForce = 550f;
                speedboostSlider.value = 0;
                jumpboostSlider.value = 0;
                jumpboost = false;
                speedboost = false;
            }
            powerupUsed = false;
        }

        if (boostUsed == false && Input.GetKeyDown(KeyCode.W))
        {
            audioSource.clip = jumpBoostSound;
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
            jumpForce = 700f;
            speedFill.color = Color.red;
            jumpFill2.color = Color.blue;
            jumpboost = true;
            boostUsed = true;
        }

        if (jumpboost == true)
        {
            jumpTimer += Time.deltaTime;
            jumpboostSlider.value = jumpTimer;

            if (jumpTimer >= 5)
            {
                jumpForce = 500;
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
                maxSpeed = 8f;
                speedTimer = 0f;
                speedboost = false;
            }
        }

        if (boostUsed == false && Input.GetKeyDown(KeyCode.Q))
        {
            audioSource.clip = speedBoostSound;
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
            maxSpeed = 12f;
            jumpFill.color = Color.red;
            speedFill2.color = Color.blue;
            speedboost = true;
            boostUsed = true;
        }

        if (Input.GetKey(KeyCode.Space) && !anim.GetBool("Slide")) {
            if(grounded) {
                audioSource.clip = jumpSound;
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.Play();
                anim.SetBool("Ground", false);
                isJumping = true;
                jumpedTime = 0;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce / 10));
            }
            
        }

        jumpedTime += Time.deltaTime;

        if (jumpedTime > maxJumpTime) {
            isJumping = false;
        }
        if (!Input.GetKey(KeyCode.Space)) {
            isJumping = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
    }

    void FixedUpdate()
    {
        if (isJumping) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce / 18));
        }
        if (!isJumping) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10));
        }
        
        roofed = Physics2D.OverlapCircle(roofCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Roof", roofed);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().velocity = new Vector2(1 * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
