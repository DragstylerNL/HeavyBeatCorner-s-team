using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    private SceneController instance;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    public void StartGame() {
        SceneManager.LoadSceneAsync("Doppel_AddingSFX");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
