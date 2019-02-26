using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour {
    [SerializeField] int damage;
    [SerializeField] float force;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER)) {
            collision.gameObject.GetComponent<Player>().ReceiveDamage(damage);
            collision.gameObject.GetComponent<Player>().SetImpulse(force);
        }
    }
}
