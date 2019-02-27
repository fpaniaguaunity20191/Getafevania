using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    enum State { InFloor, Jumping, Immune }

    [Header("Horizontal speed")]
    [SerializeField] float linearSpeed;
    [Header("Jump force")]
    [SerializeField] float jumpForce;
    [SerializeField] float health;
    [Header("Impulse force")]
    [SerializeField] float xForce;
    [SerializeField] float yForce;

    private const string ANIM_WALK = "walking";
    private State state = State.InFloor;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;
    private float x, y;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GetComponentInChildren<Weapon>().Fire();
        }
    }
    private void FixedUpdate()
    {
        Walk();        
    }
    private void Jump()
    {
        if (state == State.Jumping) {
            return;
        }
        rb2d.velocity = new Vector2(x * linearSpeed, jumpForce);
    }
    private void Walk()
    {
        if (Mathf.Abs(x) > 0) {
            animator.SetBool(ANIM_WALK, true);
            rb2d.velocity = new Vector2(x * linearSpeed, rb2d.velocity.y);
            transform.rotation = (x > 0) ? 
                Quaternion.Euler(Vector2.zero) : Quaternion.Euler(new Vector2(0, 180));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.ITEM)) {
            collision.gameObject.GetComponent<Item>().DoAction();
        } else if (collision.CompareTag(Tags.GLUE_OBJECT))
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        state = State.Jumping;
        ChangeFriction(0f);
        transform.SetParent(null);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        state = State.InFloor;
        ChangeFriction(1f);
    }
    public void ReceiveDamage(int damage)
    {
        health = health - damage;
    }
    public void SetImpulse(float force)
    {
        int multiplier = sr.flipX ? 1 : -1;
        rb2d.AddForce((new Vector2(xForce * multiplier, yForce)) * force);
        state = State.Jumping;
    }
    private void ChangeFriction(float newFriction)
    {
        PhysicsMaterial2D pm2d = GetComponent<CapsuleCollider2D>().sharedMaterial;
        pm2d.friction = newFriction;
        GetComponent<CapsuleCollider2D>().sharedMaterial = pm2d;
    }
}
