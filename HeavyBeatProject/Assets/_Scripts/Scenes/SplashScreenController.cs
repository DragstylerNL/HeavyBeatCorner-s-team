using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SplashScreenController : MonoBehaviour {
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;
    
    IEnumerator Start()
    {
        SplashScreen.Begin();
        _source.clip = _clip;
        _source.volume = 0.5f;
        _source.Play();
        while (!SplashScreen.isFinished) {
            SplashScreen.Draw();
            yield return null;
        }
    }
}