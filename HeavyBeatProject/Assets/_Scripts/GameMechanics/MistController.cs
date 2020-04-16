using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistController : MonoBehaviour {
   [Tooltip("Drag mist gameObject here.")]
   [SerializeField] private GameObject _mist;
   [Tooltip("Enter minimum height (game over) here.")]
   [SerializeField] private float _minHeight;
   [Tooltip("Enter maximum height (ceiling) here.")]
   [SerializeField] private float _maxHeight;
   [Tooltip("Amount of height per step.")]
   [SerializeField] private float _heightStep;

   [Tooltip("Height when it starts to hurt the players.")]
   [SerializeField] private float _dangerHeight = 1.5f;

   private float _currentHeight;
   
   // Action.
   public Action<float> CurrentMistHeight;
   
   // References.
   private AudioManager _audioManager;

   private void Start() {
      _audioManager = FindObjectOfType<AudioManager>();
      _failureState = FindObjectOfType<FailureState>();
      _failureState.FailedToKillEnemy += ReduceHeight;
   }

   private FailureState _failureState;
   

   private void Update() {

      if (Input.GetKeyDown(KeyCode.M)) {
         SetHeight(1.4f);
      }
   }

   //  Increases the height by _heightStep.
   private void IncreaseHeight() {
      Vector3 newHeight = _mist.transform.position;
      newHeight.y += _heightStep;
      _mist.transform.position = newHeight;
   }

   // Reduces the height by _heightStep.
   private void ReduceHeight() {
      Vector3 newHeight = _mist.transform.position;
      newHeight.y -= _heightStep;
      _currentHeight = newHeight.y;
      print("Mist is now at " + newHeight.y);
      _mist.transform.position = newHeight;
   }

   // Set mist to given height.
   private void SetHeight(float h) {
      if (h > _maxHeight) {
         print("Given float exceeds max height parameter");
         return;
      }

      if (_mist == null) {
         print("Mist object not found. Please check inspector.");
         return;
      }

      Vector3 newHeight = _mist.transform.position;
      newHeight.y = h;
      _currentHeight = h;
      _mist.transform.position = newHeight;

      
      if (_currentHeight < _dangerHeight) {
         _audioManager.Play("sfx_heartBeat");
      }
      

      print("Mist is now at " + newHeight.y);

      if (CurrentMistHeight != null) {
         CurrentMistHeight(_currentHeight);
      }
   }

   // Returns the current height.
   private float GetCurrentHeight() {
      return _currentHeight;
   }

   private void OnDestroy() {
      _failureState.FailedToKillEnemy -= ReduceHeight;
   }
}
