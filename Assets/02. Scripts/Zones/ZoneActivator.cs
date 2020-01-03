using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneActivator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToDisableOnStart;
    [SerializeField]
    private List<GameObject> objectsToEnableOnStart;
    [SerializeField]
    private List<GameObject> objectsToDisableOnEnd;
    [SerializeField]
    private List<GameObject> objectsToEnableOnEnd;

    public void OnZoneStart()
    {
        foreach(GameObject go in objectsToDisableOnStart)
        {
            go.SetActive(false);
        }
        foreach(GameObject go in objectsToEnableOnStart)
        {
            go.SetActive(true);
        }
    }

    public void OnZoneEnd()
    {
        foreach (GameObject go in objectsToDisableOnEnd)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in objectsToEnableOnEnd)
        {
            go.SetActive(false);
        }
    }
}
