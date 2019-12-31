using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK;

[RequireComponent(typeof(VRTK_InteractableObject))]
public class DrinkGestureListener : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private VRTK_InteractableObject interactableReference;
    [Header("Angle range")]
    [SerializeField]
    private Vector2 xRange; 
    [SerializeField]
    private Vector2 yRange; 
    [SerializeField]
    private Vector2 zRange;
    [SerializeField]
    private Vector3 maxAngleWithHead;
    [Header("Events")]
    [SerializeField]
    private UnityEvent onDrinkGestureDone;

    private Transform head;
    private bool isGrabbed = false;

    private void Start()
    {
        if (interactableReference == null)
        {
            interactableReference = GetComponent<VRTK_InteractableObject>();
        }
    }

    private void OnEnable()
    {
        interactableReference.InteractableObjectGrabbed += OnGrab;
        interactableReference.InteractableObjectUngrabbed += OnUngrab;
    }

    private void OnDisable()
    {
        interactableReference.InteractableObjectGrabbed -= OnGrab;
        interactableReference.InteractableObjectUngrabbed -= OnUngrab;
    }

    private void OnGrab(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = true;
    }

    private void OnUngrab(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = false;
    }
    
    private void Update()
    {
        if (isGrabbed)
        {
            if (head == null)
            {
                head = VRTK_DeviceFinder.HeadsetTransform();
            }
            
            if (head != null)
            {
                Vector3 euler = interactableReference.transform.rotation.eulerAngles;
                euler.x = Mathf.Abs(euler.x) % 360f;
                euler.y = Mathf.Abs(euler.y) % 360f;
                euler.z = Mathf.Abs(euler.z) % 360f;
                if (euler.x > xRange.x && euler.x < xRange.y)
                {
                    if (euler.y > yRange.x && euler.y < yRange.y)
                    {
                        if (euler.z > zRange.x && euler.z < zRange.y)
                        {
                            if (head.transform.position.y < interactableReference.transform.position.y)
                            {
                                onDrinkGestureDone.Invoke();
                            }
                        }
                    }
                }
            }
        }
    }
}
