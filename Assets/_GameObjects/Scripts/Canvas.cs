using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {
    public Text txtScore;
    public Image[] imgLives;
	void Start () {
        foreach (Image img in imgLives) {
            img.enabled = false;
        }
    }
	
	void Update () {
        txtScore.text = GameManager.Points.ToString();
        for (int i = 0; i < GameManager.Lives; i++) {
            imgLives[i].enabled = true;
        }
	}
}
