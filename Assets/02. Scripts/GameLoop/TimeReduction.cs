using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReduction : MonoBehaviour
{
    [SerializeField]
    private ScriptableFloat zoneTimeReference;
    [SerializeField]
    private GameEvent loseEvent;
    [SerializeField]
    private bool startReducingOnStart;

    private bool currentlyReducing = true;

    void Start()
    {
        zoneTimeReference.ResetValue();
        if (startReducingOnStart)
        {
            StartReducing();
        }
    }

    private void Update()
    {
        if (currentlyReducing)
        {
            zoneTimeReference.IncrementValue(-Time.deltaTime);

            if (zoneTimeReference.GetValue() <= 0f)
            {
                loseEvent.Raise();
            }
        }
    }

    public void StartReducing()
    {
        currentlyReducing = true;
    }

    public void StopReducing()
    {
        currentlyReducing = false;
    }
}
