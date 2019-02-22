using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Vector2 startPosition;
    public Transform endPosition;
    private float pct;//Porcentaje de avance
    public float speed;
    private void Start()
    {
        startPosition = transform.position;
    }

    void Update () {
        pct = pct + Time.deltaTime * speed;
        transform.position = 
            Vector2.Lerp(startPosition, endPosition.position, pct);
        if(pct>1 || pct < 0) {
            speed = speed * -1;
        }
	}
}
