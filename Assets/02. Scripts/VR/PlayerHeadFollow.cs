using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayerHeadFollow : MonoBehaviour
{
    private Transform head;

    private void Start()
    {
        StartCoroutine(FindHead());
    }

    private void Update()
    {
        if (head != null)
        {
            transform.position = head.position;
            transform.rotation = head.rotation;
        }
    }

    private IEnumerator FindHead()
    {
        while (head == null)
        {
            head = VRTK_DeviceFinder.HeadsetTransform();
            yield return null;
        }
    }
}
