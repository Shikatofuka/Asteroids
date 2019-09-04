using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {


    public Text score;
    public int points ;
    public static GameManagerScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start() {

    }

    void Update()
    {
        points = Enemy1ControllerScript.points;
        score.text = "" + points;
    }

    public void SaveScore() {
        if (PlayerPrefs.GetInt("HighScore") < points) {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }

}
