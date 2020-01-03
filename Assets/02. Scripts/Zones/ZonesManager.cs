using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesManager : MonoBehaviour
{
    [SerializeField]
    private List<Zone> zones;
    
    void Start()
    {
        if (zones.Count > 0)
        {
            zones[0].gameObject.SetActive(true);
        }
        if (zones.Count > 1)
        {
            for (int i = 1; i < zones.Count; ++i)
            {
                zones[i].gameObject.SetActive(false);
            }
        }
    }

    public void NextZoneStart()
    {
        if (zones.Count > 0)
        {
            if (!GetNextZone().HasStarted())
            {
                GetNextZone().StartZone();
            }
            else
            {
                GetNextZone().Recenter();
            }
        }
    }

    public void FinishZone()
    {
        GetNextZone().FinishZone();
        zones.RemoveAt(0);
        if (zones.Count > 0)
        {
            GetNextZone().gameObject.SetActive(true);
        }
    }

    private Zone GetNextZone()
    {
        return zones[0];
    }
}
