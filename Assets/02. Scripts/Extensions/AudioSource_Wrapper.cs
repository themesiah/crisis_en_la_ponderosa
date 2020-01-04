using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSource_Wrapper : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    public void ChangeVolume(ScriptableFloat volumeReference)
    {
        source.volume = volumeReference.GetValue();
    }
}
