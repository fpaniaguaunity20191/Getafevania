using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {
    public Text txtScore;
	void Start () {
		
	}
	
	void Update () {
        txtScore.text = GameManager.Points.ToString();
	}
}
