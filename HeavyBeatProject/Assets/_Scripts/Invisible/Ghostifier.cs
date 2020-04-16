using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostifier : MonoBehaviour
{
    [SerializeField] private List<int> _maskIndexes;
    private Camera _cam;
    
    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    public void Ghostify(bool visible)
    {
        int newMask;
        if (visible)
        {
            for (int i = 0; i < _maskIndexes.Count; i++)
            {
                newMask = _cam.cullingMask | (1<<_maskIndexes[i]);
                _cam.cullingMask = newMask;
            }
        }
        else
        {
            for (int i = 0; i < _maskIndexes.Count; i++)
            {
                newMask = _cam.cullingMask & ~(1<<_maskIndexes[i]);
                _cam.cullingMask = newMask;
            }
        }
    }
}
