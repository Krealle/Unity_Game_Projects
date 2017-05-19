using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    public Canvas pauseMenu;
    public Canvas optionsMenu;
    public Button resumeText;
    public Button menuText;
    public bool isPaused = false;
    public bool isOptions = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) {
            PausePress();
        } else if (Input.GetKeyDown(KeyCode.Escape) && isPaused) {
            if(isOptions) {
                PausePress();
            } else {
                ResumePress();
            }
        }
    }

    void Start() {
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        resumeText = resumeText.GetComponent<Button>();
        menuText = menuText.GetComponent<Button>();
        pauseMenu.enabled = false;
        optionsMenu.enabled = false;
    }

    public void PausePress() {
        pauseMenu.enabled = true;
        optionsMenu.enabled = false;
        resumeText.enabled = true;
        menuText.enabled = true;
        isPaused = true;
        isOptions = false;
        Time.timeScale = 0f;
    }

    public void MenuPress() {
        Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }

    public void ResumePress() {
        Time.timeScale = 1.0f;
        pauseMenu.enabled = false;
        isPaused = false;
    }

    public void OptionsPress() {
        pauseMenu.enabled = false;
        optionsMenu.enabled = true;
        isOptions = true;
    }
}
