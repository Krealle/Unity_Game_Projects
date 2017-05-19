using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PursuitControl : MonoBehaviour
{
    public float maxSpeed = 8.5f;
    Rigidbody2D rig;
    Animator anim;
    bool grounded = false;
    public Transform groundCheck;
    public Transform roofCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 400f;

    public Transform rayBottomPos, rayTopPos, rayDownPos;
    public float rayBottomLength, rayTopLength, rayDownLength;
    public LayerMask rayLayerMask;

    private float slideDuration = 0.3f;

    private bool canJump = true;
    private GameObject player;

    private Vector3 pursuitRespawn;

    public CharacterControl playerControl;

    public float increaseTimer;
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        maxSpeed = 8.5f;
        player = GameObject.FindGameObjectWithTag("Player");
        increaseTimer = 0;
    }

    void Update()
    {
        increaseTimer += Time.deltaTime;
        if (increaseTimer > 6) {
            maxSpeed += 0.1f;
            increaseTimer = 0;
        }

        player = GameObject.FindGameObjectWithTag("Player");
        if(transform.position.x >= (player.transform.position.x - 1.5f)){
            playerControl.LoseGame();
        }

        if (transform.position.y < -8) {
            pursuitRespawn.x = player.transform.position.x - 20;
            pursuitRespawn.y = player.transform.position.y;
            transform.position = pursuitRespawn;
        }

        bool hitBot = CheckRay(rayBottomPos.position, rayBottomLength);
        bool hitTop = CheckRay(rayTopPos.position, rayTopLength);
        bool hitDown = !Physics2D.Raycast(rayDownPos.position, Vector2.down, rayDownLength, rayLayerMask);

        if (grounded && (hitBot || hitDown) && canJump)
        {
            StartCoroutine(Jump());
        }
        else if (hitTop && !anim.GetBool("Slide")) 
        {
            StartCoroutine(Slide());
        }

        if(hitBot && hitTop)
        {
            Debug.LogError("wtf m8");
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        anim.SetBool("Roof", Physics2D.OverlapCircle(roofCheck.position, groundRadius, whatIsGround));
    }
    void FixedUpdate()
    {
        anim.SetFloat("vSpeed", rig.velocity.y);
        rig.velocity = new Vector2(1 * maxSpeed, rig.velocity.y);
    }

    private bool CheckRay(Vector2 pos, float length)
    {
        return Physics2D.Raycast(pos, Vector2.right, length, rayLayerMask);
    }

    private IEnumerator Jump()
    {
        print("jump");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        canJump = false;
        yield return new WaitForSeconds(0.2f);
        canJump = true;
    }

    private IEnumerator Slide()
    {
        anim.SetBool("Slide", true);
        yield return new WaitForSeconds(slideDuration);
        anim.SetBool("Slide", false);
    }
}
