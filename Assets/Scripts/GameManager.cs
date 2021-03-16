using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool GameOver { get; private set; }
    public Color gameOverColor;
    public float deathTimer;
    int score = 0;

    void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (GameOver) deathTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && deathTimer < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Reset your highscore
        if(Input.GetKey(KeyCode.R) && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("Highscore", 0);
        }
    }

    public void EndGame()
    {
        GameOver = true;
        Camera.main.backgroundColor = gameOverColor;
        if (PlayerPrefs.GetInt("Highscore") < score) PlayerPrefs.SetInt("Highscore", score);
    }

    public void IncreaseScore()
    {
        score++;
        SFXManager.Instance.PlayScore();
        Debug.Log("Score increased to :" + score);
    }
}
