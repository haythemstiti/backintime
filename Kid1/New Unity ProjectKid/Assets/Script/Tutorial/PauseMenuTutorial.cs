using UnityEngine;
using System.Collections;

public class PauseMenuTutorial : MonoBehaviour {

    private GameObject imageGamePaused, imagePause;
	void Start () {

        imageGamePaused = GameObject.Find("imageGamePaused");
        imageGamePaused.SetActive(false);

        imagePause = GameObject.Find("imagePause");
	}
	
	void Update () {
	
	}
    public void PauseGame() 
    {
        Time.timeScale = 0f;
        imageGamePaused.SetActive(true);
        imagePause.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        imageGamePaused.SetActive(false);
        imagePause.SetActive(true);
    }
    public void MainMenuGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("menu2");
    }
}
