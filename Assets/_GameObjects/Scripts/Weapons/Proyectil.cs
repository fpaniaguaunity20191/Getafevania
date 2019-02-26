using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
    public float force;
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
	}
}
