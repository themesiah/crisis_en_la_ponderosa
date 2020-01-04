using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private RuntimeSingleGameObject playerHeadReference;

    [Header("Parameters")]
    [SerializeField]
    private bool rotateOnX;
    [SerializeField]
    private bool rotateOnY;
    [SerializeField]
    private bool rotateOnZ;
    [SerializeField]
    private bool rotateOnStart;
    [SerializeField]
    private float rotationSpeed = 1f;

    private bool isRotating = false;
    private Vector3 targetEuler;

    private void Start()
    {
        if (rotateOnStart)
        {
            DoRotate();
        }
        Vector3 lastEuler = transform.rotation.eulerAngles;
        transform.LookAt(playerHeadReference.Get().transform);
        targetEuler = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(lastEuler);

        if (!rotateOnX)
        {
            targetEuler.x = lastEuler.x;
        }

        if (!rotateOnY)
        {
            targetEuler.y = lastEuler.y;
        }

        if (!rotateOnZ)
        {
            targetEuler.z = lastEuler.z;
        }
    }

    public void DoRotate()
    {
        isRotating = true;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetEuler), rotationSpeed * Time.deltaTime);
    }
}
