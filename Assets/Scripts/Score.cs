using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        scoreValue = 0;
        scoreValue = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SCORE: " + scoreValue;
        PlayerPrefs.SetInt("Score", scoreValue);
    }

    void OnDisable()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.Save();
    }
}
