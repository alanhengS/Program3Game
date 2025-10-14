/***************************************************************
*file: GameEndUI.cs
*author: Adam Khalil
*class: CS 4700 – Game Development
*assignment: Program 3
*date last modified: 10/13/2025
*
*purpose: This program indicates when the game has ended, pauses, and restarts. 
*
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
    public GameObject endGamePanel;

    bool isShown = false;

    void Awake()
    {
        if (endGamePanel != null) endGamePanel.SetActive(false);
    }

    public void Show()
    {
        if (isShown) return;
        isShown = true;

        if (endGamePanel != null) endGamePanel.SetActive(true);
        Time.timeScale = 0f; // pause game
    }

    public void Hide()
    {
        if (!isShown) return;
        isShown = false;

        if (endGamePanel != null) endGamePanel.SetActive(false);
        Time.timeScale = 1f; // resume
    }

    // --- Button Hooks --- 
    public void OnRestartButton()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
}
