using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformCount = 300;
    public GameObject titleScreen;
    public GameObject ControlsMenu;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = false;
    public bool isGameOver = false;
    public GameObject pauseScreen;
    public TextMeshProUGUI scoreText;
    private bool paused;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(3.5f, 0.5f);
            spawnPosition.x = Random.Range(-10.0f, 10.0f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.Select();
        isGameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
