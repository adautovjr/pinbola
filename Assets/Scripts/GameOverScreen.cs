using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    public void Setup(int score, int highscore) {
        scoreText.text = "You got " + score.ToString() + " Points!";
        highscoreText.text = "Highscore: " + highscore.ToString();
        gameObject.SetActive(true);
    }
}
