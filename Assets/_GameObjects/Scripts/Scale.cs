using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {
    [Range(1,10)]
    public float upperScaleLimit;
    [Range(0, 10)]
    public float bottomScaleLimit;
    public float scaleSpeed;
    private float scale = 1;
    void Update () {
        scale = scale + scaleSpeed * Time.deltaTime;
        if (scale > upperScaleLimit || scale < bottomScaleLimit) {
            scaleSpeed = scaleSpeed * -1;
        } 
        transform.localScale = new Vector2(scale, scale);
	}
}
