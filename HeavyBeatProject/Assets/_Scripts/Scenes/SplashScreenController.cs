using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SplashScreenController : MonoBehaviour {
    private AudioManager _audioManager;
    
    IEnumerator Start()
    {
        SplashScreen.Begin();
        _audioManager = FindObjectOfType<AudioManager>();
        _audioManager.Play("");
        while (!SplashScreen.isFinished) {
            SplashScreen.Draw();
            yield return null;
        }
        Debug.Log("Finished showing splash screen");
    }
}