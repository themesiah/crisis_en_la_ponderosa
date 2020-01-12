using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Others/ScriptableAudioClip")]
public class ScriptableAudioClip : ScriptableObject
{
    [SerializeField]
    private List<AudioClip> clips;

    [SerializeField]
    private Vector2 minMaxPitch;

    [SerializeField]
    private AnimationCurve pitchCurve;

    public AudioClip GetClip()
    {
        return clips[Random.Range(0, clips.Count)];
    }

    public float GetPitch()
    {
        float rand = Random.value;
        float curveValue = pitchCurve.Evaluate(rand);
        float val = Mathf.Lerp(minMaxPitch.x, minMaxPitch.y, curveValue);
        return val;
       // return Random.Range(minMaxPitch.x, minMaxPitch.y);
    }
}
