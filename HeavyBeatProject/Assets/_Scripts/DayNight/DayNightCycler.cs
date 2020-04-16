using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DayNightCycler : MonoBehaviour
{
    [SerializeField] private Transform _sun;
    [SerializeField] private float _speedDay = 0.5f;
    [SerializeField] private float _speedNight = 0.1f;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private bool _isDay = true;
    [SerializeField] private bool _cycle = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = _speedDay;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_cycle) return;

        if (_isDay)
        {
            if (_rotation.y == 180 && _rotation.z == 180 && (_rotation.x <= 360f && _rotation.x >= 270f))
            {
                _isDay = !_isDay;
                _currentSpeed = _speedNight;
            }
        }
        else
        {
            if (_rotation.y == 0 && _rotation.z == 0 && (_rotation.x <= 90f && _rotation.x >= 0f))
            {
                _isDay = !_isDay;
                _currentSpeed = _speedDay;
            }
        }
        _sun.Rotate(_currentSpeed,0,0, Space.Self);
        _rotation = _sun.rotation.eulerAngles;
    }
}
