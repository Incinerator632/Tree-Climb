using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButton : MonoBehaviour
{
    private Button button;
    public GameObject controlPanel;
    public GameObject titleScreen;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ControlsButtonPressed);
    }

    public void ControlsButtonPressed()
    {
        controlPanel.SetActive(true);
        backButton.Select();
        titleScreen.SetActive(false);
    }
}
