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
    int score;

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
    }

    public void EndGame()
    {
        GameOver = true;
        Camera.main.backgroundColor = gameOverColor;
    }

    public void IncreaseScore()
    {
        score++;
    }
}
