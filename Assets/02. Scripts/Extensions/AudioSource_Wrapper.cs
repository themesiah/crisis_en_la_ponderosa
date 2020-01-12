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

    public void PlayClip(ScriptableAudioClip audioClip)
    {
        AudioClip clip = audioClip.GetClip();
        float pitch = audioClip.GetPitch();
        source.pitch = pitch;
        source.PlayOneShot(clip);
    }
}
