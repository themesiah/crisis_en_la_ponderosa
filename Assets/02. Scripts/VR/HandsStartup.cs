using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsStartup : MonoBehaviour
{
    [SerializeField]
    private ScriptableBool leftHandedReference;
    [SerializeField]
    private bool rightHand;
    [SerializeField]
    private GameObject[] mainHandObjects;
    [SerializeField]
    private GameObject[] secondaryHandObjects;

    void Start()
    {
        bool leftHanded = leftHandedReference.GetValue();
        foreach(GameObject go in mainHandObjects)
        {
            if (rightHand)
                go.SetActive(!leftHanded);
            else
                go.SetActive(leftHanded);
        }
        foreach(GameObject go in secondaryHandObjects)
        {
            if (rightHand)
                go.SetActive(leftHanded);
            else
                go.SetActive(!leftHanded);
        }
    }
}
