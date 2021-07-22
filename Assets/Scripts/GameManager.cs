using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int highscore = 0;
    public int lives = 3;
    public GameOverScreen GameOverScreen;
    public GameObject Ball;
    public GameObject Spawner;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        lives = 3;
        ScoreManager.instance.UpdateLives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        score += points;
        if (highscore <= score) {
            highscore = score;
            PlayerPrefs.SetInt("highscore", score);
        }
        ScoreManager.instance.AddPoints(points, score, highscore);
    }

    public void GameOver() {
        GameOverScreen.Setup(score, highscore);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void LoseLife() {
        if (lives <= 0) {
            GameOver();
            return;
        }
        lives -= 1;
        
        Ball.transform.position = Spawner.transform.position;
        ScoreManager.instance.UpdateLives();
    }
}
