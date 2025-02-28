﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    public AudioManager audioManager;
    public string nameOfMainMenu = "menu";
    public GameObject mainPausePanel;
    public GameObject quitToMenuPanel;
    public GameObject quitGamePanel;
    public GameObject settingsPanel;

    private float fixedDeltaTime = 0.02f;

    public void Pause()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(true);
        Time.timeScale = 0;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        Cursor.visible = true;
        LevelManager.isPause = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // =========================================== MAIN PAUSE ===================================

    public void ButtonResume()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(false);
        if(!tutoController.isSpeaking)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        Time.timeScale = 1;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        LevelManager.isPause = false;
        
    }

    public void ButtonQuitToMenu()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(false);
        quitToMenuPanel.SetActive(true);
    }

    public void ButtonQuitToWindows()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(false);
        quitGamePanel.SetActive(true);
    }

    public void ButtonSettings()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ButtonCloseSettings()
    {
        audioManager.PlayButton();
        settingsPanel.SetActive(false);
        mainPausePanel.SetActive(true);
    }

    // ========================================== CONFIRM RETURN MENU ===================================

    public void ButtonYesGoMenu()
    {
        audioManager.PlayButton();
        PlayerPrefs.SetString("save", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("dieCounter", DieCounterController.matriculationNumber);
        LevelManager.isPause = false;
        SceneManager.LoadScene(nameOfMainMenu);
    }

    public void ButtonNoGoMenu()
    {
        audioManager.PlayButton();
        quitToMenuPanel.SetActive(false);
        mainPausePanel.SetActive(true);

    }

    // ========================================= CONFIRM QUIT GAME =========================================

    public void ButtonYesQuitGame()
    {
        audioManager.PlayButton();
        PlayerPrefs.SetString("save", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("dieCounter", DieCounterController.matriculationNumber);
        LevelManager.isPause = false;
        Application.Quit();
    }

    public void ButtonNoQuitGame()
    {
        audioManager.PlayButton();
        quitGamePanel.SetActive(false);
        mainPausePanel.SetActive(true);
    }
}