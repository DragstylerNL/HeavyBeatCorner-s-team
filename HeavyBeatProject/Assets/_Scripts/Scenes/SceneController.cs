using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    private SceneController instance;
    private AudioManager _audioManager;

    private void Start() {
        _audioManager = FindObjectOfType<AudioManager>();
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
        _audioManager.Play("sfx_backgroundNoise");;
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ButtonClick() {
        _audioManager.Play("sfx_buttonClick");
    }
}
