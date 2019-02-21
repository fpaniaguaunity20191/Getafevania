using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float linearSpeed;//Velocidad horizontal
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private float x, y;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Walk();        
    }
    private void Walk()
    {
        if (Mathf.Abs(x) > 0) {
            rb2d.velocity = new Vector2(x * linearSpeed, 0);
            /* Version 'tradicional'
            if (x<0) {
                sr.flipX = true;
            } else {
                sr.flipX = false;
            }
            */
            /* Ternaria
            sr.flipX = x < 0 ? true : false;
            */
            sr.flipX = (x < 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.ITEM)) {
            collision.gameObject.GetComponent<Item>().DoAction();
            //collision.gameObject.GetComponent("Item");
        }
    }
}
