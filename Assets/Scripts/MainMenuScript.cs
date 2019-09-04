using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public Text highScoreText;


    void Start() {
        highScoreText.text = "" + PlayerPrefs.GetInt("HighScore");
    }

    public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame() {
        Application.Quit();
    }

    void Update() {
        
    }
}
