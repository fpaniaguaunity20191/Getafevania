using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour {
    [SerializeField] int health;
    [SerializeField] Transform endPos;
    Vector3 initPos;
    [SerializeField] float speed;
    [SerializeField] int damage;
    float pct = 0;
    private void Awake()
    {
        initPos = transform.position;
    }

    void Update () {
        pct = pct + Time.deltaTime * speed;
        if (pct >= 1 || pct <= 0)
        {
            speed = speed * -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            if (pct > 1)
            {
                pct = 1;
            } else if (pct < 0)
            {
                pct = 0;
            }
        }
        transform.position = Vector2.Lerp(initPos, endPos.position, pct);
	}

    public void ReceiveDamage(int damage)
    {
        health = health - damage;
        GetComponentInChildren<Slider>().value = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            collision.gameObject.GetComponent<Player>().ReceiveDamage(damage);
        }
    }

}
