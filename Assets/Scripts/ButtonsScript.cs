using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour {

    private bool isPaused = false;
    public GameObject pausePanel;

    public void Pause() {
        if (isPaused == false) {
            isPaused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        } else {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

    public void Restart() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

    public void ExitToMainMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }


    


}
