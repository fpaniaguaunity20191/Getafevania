using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour {
    [SerializeField] GameObject panelMenu;
    public Text txtScore;
    public Image[] imgLives;
    void Start () {
        foreach (Image img in imgLives) {
            img.enabled = false;
        }
    }
	
	void Update () {
        txtScore.text = GameManager.Points.ToString();
        //Desactivamos todos los corazones
        for (int i = 0; i < GameManager.NUM_MAX_LIVES; i++)
        {
            imgLives[i].enabled = false;
        }
        //Activamos los corazones correspondientes a la vidas que me quedan
        for (int i = 0; i < GameManager.Lives; i++) {
            imgLives[i].enabled = true;
        }
        //Si pulsa 'scape' muestra el menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelMenu.SetActive(!panelMenu.activeSelf);
            Time.timeScale = (panelMenu.activeSelf) ? 0f : 1f;
        }
	}

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
    public void ContinuePlaying()
    {
        panelMenu.SetActive(false);
        Time.timeScale = 1;
    }
    
}
