using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PursuitControlOLD: MonoBehaviour 
{
    public float maxSpeed = 10f;
    Rigidbody2D rig;
    Animator anim;
    bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 400f;
	void Start ()   
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
	}
	
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Jump") {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        } else if (other.tag == "Crouch") {
            //Code
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            Application.LoadLevel(2);
        }
    }
	void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);



        anim.SetFloat("vSpeed", rig.velocity.y);

       rig.velocity = new Vector2(1 * maxSpeed, rig.velocity.y);
	}
}
