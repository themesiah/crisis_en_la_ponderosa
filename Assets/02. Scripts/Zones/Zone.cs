using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zone : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent onZoneStart;
    [SerializeField]
    private UnityEvent onZoneEnd;
    [SerializeField]
    private GameEvent startReducing;
    [SerializeField]
    private GameEvent stopReducing;

    [Header("References")]
    [SerializeField]
    private ScriptableFloat timeReference;
    [SerializeField]
    private PlayerRecenter recenter;
    [SerializeField]
    private ScriptableInt pointsReference;
    [SerializeField]
    private ScriptableInt pointsPerSecond;
    [SerializeField]
    private Spawner spawner;
    [SerializeField]
    private ZoneActivator zoneActivator;
    [SerializeField]
    private GameEvent zoneStartEvent;

    [Header("Parameters")]
    [SerializeField]
    private ScriptableFloat timeAtEndReference;

    private bool hasStarted = false;

    public void StartZone()
    {
        Recenter();
        startReducing.Raise();
        zoneStartEvent.Raise();
        onZoneStart.Invoke();
        spawner.SpawnCurrentList();
        if (zoneActivator != null)
        {
            zoneActivator.OnZoneStart();
        }
        hasStarted = true;
    }

    public void FinishZone()
    {
        stopReducing.Raise();

        float restingTime = timeReference.GetValue();
        pointsReference.IncrementValue((int)restingTime * pointsPerSecond.GetValue());

        timeReference.IncrementValue(timeAtEndReference.GetValue());

        onZoneEnd.Invoke();
        if (zoneActivator != null)
        {
            zoneActivator.OnZoneEnd();
        }
    }

    public bool HasStarted()
    {
        return hasStarted;
    }

    public void Recenter()
    {
        recenter.Recenter();
    }
}
