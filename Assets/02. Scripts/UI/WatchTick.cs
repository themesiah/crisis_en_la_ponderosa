using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WatchTick : MonoBehaviour
{
    [SerializeField]
    private ScriptableFloat timeReference;
    [SerializeField]
    private FloatUnityEvent onWatchTick;
    [SerializeField]
    private float timeForWatchTick = 10f;
    [SerializeField]
    private Vector2 minMaxWatchTick;
    [SerializeField]
    private float ticksPerSecond = 2f;

    private Coroutine tickCoroutine;
    private float currentRate = 0f;

    private void OnTimeChanged(float newTime)
    {
        if (newTime <= timeForWatchTick)
        {
            currentRate = GetRate(newTime);
            if (tickCoroutine == null)
            {
                tickCoroutine = StartCoroutine(TickCoroutine());
            }
        } else
        {
            currentRate = 0f;
        }
    }

    private float GetRate(float time)
    {
        return Mathf.Lerp(minMaxWatchTick.x, minMaxWatchTick.y, Mathf.Pow(Mathf.InverseLerp(timeForWatchTick, 0f, time), 2f));
    }

    private void OnEnable()
    {
        timeReference.AddOnValueChangeCallback(OnTimeChanged);
    }

    private void OnDisable()
    {
        timeReference.RemoveOnValueChangeCallback(OnTimeChanged);
    }

    private IEnumerator TickCoroutine()
    {
        while (currentRate != 0f)
        {
            onWatchTick.Invoke(currentRate);
            yield return new WaitForSeconds(1f/ ticksPerSecond);
        }
        tickCoroutine = null;
    }
}
