using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayerRecenter : MonoBehaviour
{
    [SerializeField]
    private bool recenterOnStart;
    [SerializeField]
    private RuntimeSingleGameObject SDKManagerSingle;
    [SerializeField]
    private Transform pivot;
    [SerializeField]
    private float hardcodedY = 1.65f;

    private void Start()
    {
        if (recenterOnStart)
        {
            Recenter();
        }
    }

    public void Recenter()
    {
        StartCoroutine(RecenterCoroutine());
    }

    private IEnumerator RecenterCoroutine()
    {
        Transform head = VRTK_DeviceFinder.HeadsetTransform();
        while (head == null)
        {
            yield return null;
            head = VRTK_DeviceFinder.HeadsetTransform();
        }
        Vector3 pos = pivot.position - head.localPosition;
        pos.y = hardcodedY + pivot.position.y - head.localPosition.y;
        SDKManagerSingle.Get().transform.position = pos;
        Vector3 euler = Vector3.zero;
        euler.y = pivot.rotation.eulerAngles.y;
        euler.y -= head.localRotation.eulerAngles.y;
        SDKManagerSingle.Get().transform.rotation = Quaternion.Euler(euler);
        yield return null;
    }
}
