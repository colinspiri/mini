using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public static GameOverManager Instance;

    public GameObject winPanel;
    public GameObject losePanel;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetKeyDown(KeyCode.Q)) Application.Quit();
    }

    public void PlayerWin() {
        winPanel.SetActive(true);
    }

    public void PlayerLose() {
        losePanel.SetActive(true);
    }
}
