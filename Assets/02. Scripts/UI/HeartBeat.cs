using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FloatUnityEvent : UnityEvent<float> { }

public class HeartBeat : MonoBehaviour
{
    [SerializeField]
    private ScriptableFloat stressReference;
    [SerializeField]
    private FloatUnityEvent onHeartBeat;
    [SerializeField]
    private float minStressForHeartbeat = 0.5f;
    [SerializeField]
    private Vector2 minMaxHeartbeatPitch;
    [SerializeField]
    private float heartbeatsPerSecond = 2f;

    private Coroutine heartbeatCoroutine;
    private float currentRate = 0f;

    private void OnStressChanged(float newStress)
    {
        if (newStress >= minStressForHeartbeat)
        {
            currentRate = GetRate(newStress);
            if (heartbeatCoroutine == null)
            {
                heartbeatCoroutine = StartCoroutine(HeartbeatCoroutine());
            }
        } else
        {
            currentRate = 0f;
        }
    }

    private float GetRate(float stress)
    {
        return Mathf.Lerp(minMaxHeartbeatPitch.x, minMaxHeartbeatPitch.y, Mathf.Pow(Mathf.InverseLerp(minStressForHeartbeat, 1f, stress), 2f));
    }

    private void OnEnable()
    {
        stressReference.AddOnValueChangeCallback(OnStressChanged);
    }

    private void OnDisable()
    {
        stressReference.RemoveOnValueChangeCallback(OnStressChanged);
    }

    private IEnumerator HeartbeatCoroutine()
    {
        while (currentRate != 0f)
        {
            onHeartBeat.Invoke(currentRate);
            yield return new WaitForSeconds(1f/heartbeatsPerSecond);
        }
        heartbeatCoroutine = null;
    }
}
