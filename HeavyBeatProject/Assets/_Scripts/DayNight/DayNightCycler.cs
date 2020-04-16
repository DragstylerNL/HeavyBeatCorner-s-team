using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DayNightCycler : MonoBehaviour
{
    [SerializeField] private Transform _sun;
    [SerializeField] private bool _cycle = true;
    [SerializeField] private float _speedDay = 0.5f;
    [SerializeField] private float _speedNight = 0.1f;
    
    private float _currentSpeed;
    private Vector3 _rotation;
    private Ghostifier[] _ghostifiers;
    private bool _isDay = true;
    public bool isDay { get { return _isDay; } }
    
    void Start()
    {
        _currentSpeed = _speedDay;
        _ghostifiers = FindObjectsOfType<Ghostifier>();
    }

    void Update()
    {
        if (!_cycle) return;

        if (_isDay)
        {
            if (_rotation.y == 180 && _rotation.z == 180 && (_rotation.x <= 360f && _rotation.x >= 270f))
            {
                _isDay = !_isDay;
                _currentSpeed = _speedNight;
                VisiblePlayers(false);
            }
        }
        else
        {
            if (_rotation.y == 0 && _rotation.z == 0 && (_rotation.x <= 90f && _rotation.x >= 0f))
            {
                _isDay = !_isDay;
                _currentSpeed = _speedDay;
                VisiblePlayers(true);
            }
        }
        _sun.Rotate(_currentSpeed,0,0, Space.Self);
        _rotation = _sun.rotation.eulerAngles;
    }

    private void VisiblePlayers(bool visible)
    {
        for (int i = 0; i < _ghostifiers.Length; i++)
        {
            _ghostifiers[i].Ghostify(visible);
        }
    }
}
