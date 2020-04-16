using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_SoundCollection", menuName = "ScriptableObjects/SoundCollection")]
public class SoundCollection : ScriptableObject
{
    public Sound[] soundCollection;
}
