using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {
    [SerializeField] Transform endPos;
    Vector3 initPos;
    [SerializeField] float speed;
    float pct = 0;
    private void Awake()
    {
        initPos = transform.position;
    }

    void Update () {
        pct = pct + Time.deltaTime * speed; 
        if (pct>=1 || pct <= 0)
        {
            speed = speed * -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
        transform.position = Vector2.Lerp(initPos, endPos.position, pct);
	}
}
