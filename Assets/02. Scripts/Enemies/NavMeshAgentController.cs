using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    private NavMeshAgent nma;
    [SerializeField]
    private float thresholdDistance = 0.5f;
    [SerializeField]
    private Transform targetLocation;
    [SerializeField]
    private bool executeOnStart;
    [SerializeField]
    private bool destroyOnArrival;
    [Header("Events")]
    [SerializeField]
    private UnityEvent onStart;
    [SerializeField]
    private UnityEvent onArrival;




    private bool started = false;
    private float lastSpeed = 0f;

    private void Start()
    {
        if (executeOnStart)
        {
            Execute();
        }
    }

    public void Execute()
    {
        if (targetLocation != null)
        {
            onStart?.Invoke();
            nma.SetDestination(targetLocation.position);
            started = true;
        }
    }

    private void Update()
    {
        if (started == true)
        {
            if (Vector3.Distance(transform.position, targetLocation.position) < thresholdDistance)
            {
                Arrival();
            }
            if (lastSpeed != nma.speed)
            {
                lastSpeed = nma.speed;
            }
        }
    }

    private void Arrival()
    {
        Stop();
        onArrival?.Invoke();
        if (destroyOnArrival)
        {
            Destroy(this);
        }
    }

    public void Stop()
    {
        started = false;
        nma.isStopped = true;
    }
}
