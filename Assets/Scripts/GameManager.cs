using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public int platformCount = 300;
    public GameObject platformPrefab;
    public GameObject titleScreen;
    public GameObject ControlsMenu;
    public Button restartButton;
    public GameObject pauseScreen;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = false;
    public bool isGameOver = false;
    private bool paused;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(3.5f, 0.5f);
            spawnPosition.x = Random.Range(-10.0f, 10.0f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        spawnManager.SpawnPowerUp();
        spawnManager.SpawnPowerUp2();
        spawnManager.SpawnPowerUp3();
        spawnManager.SpawnPowerUp4();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver();
        }
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
        Debug.Log(isGameOver);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
