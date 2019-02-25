using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
	
}
