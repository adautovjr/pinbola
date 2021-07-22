using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public Text livesText;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.instance.score.ToString() + " Points";
        highscoreText.text = "Highscore: " + GameManager.instance.highscore.ToString();
    }

    public void AddPoints(int points, int score, int highscore) {
        scoreText.text = score.ToString() + " Points";
        if (highscore <= score) {
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
    }

    public void UpdateLives() {
        livesText.text = "Lives: " + GameManager.instance.lives.ToString();
    }
}
