using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathFade : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onFadeEvent;
    [SerializeField]
    private UnityEvent onUnfadeEvent;

    public void DoFade()
    {
        PlayerFade.instance.Fade(onFadeEvent, onUnfadeEvent);
    }
}
