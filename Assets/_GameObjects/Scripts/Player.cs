using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float linearSpeed;//Velocidad horizontal
    private Rigidbody2D rb2d;
    private float x, y;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ORANGE");
    }
}
