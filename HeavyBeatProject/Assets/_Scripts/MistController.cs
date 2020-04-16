using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistController : MonoBehaviour {
   [Tooltip("Drag mist prefab here.")]
   [SerializeField] private GameObject _mist;
   [Tooltip("Enter minimum height (game over) here.")]
   [SerializeField] private float _minHeight;
   [Tooltip("Enter maximum height (ceiling) here.")]
   [SerializeField] private float _maxHeight;
   [Tooltip("Amount of height per step.")]
   [SerializeField] private float _heightStep;

   private float _currentHeight;
   
   public Action<float> CurrentMistHeight;


   private void Update() {
      // Dev testing.
      // if (Input.GetKeyDown(KeyCode.D)) {
      //    ReduceHeight();
      // }
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
      
      if (CurrentMistHeight != null) {
         CurrentMistHeight(_currentHeight);
      }
   }

   // Returns the current height.
   private float GetCurrentHeight() {
      return _currentHeight;
   }
}
