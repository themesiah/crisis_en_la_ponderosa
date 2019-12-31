using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRInputManager : MonoBehaviour
{
    [Header("Controllers (input)")]
    [SerializeField]
    private RuntimeSingleVRController leftController;
    [SerializeField]
    private RuntimeSingleVRController rightController;

    [Header("Controller events")]
    [SerializeField]
    private GameEvent leftTriggerEvent;
    [SerializeField]
    private GameEvent leftDownEvent;
    [SerializeField]
    private GameEvent leftButton1Event;
    [SerializeField]
    private GameEvent leftButton2Event;
    [SerializeField]
    private GameEvent rightTriggerEvent;
    [SerializeField]
    private GameEvent rightDownEvent;
    [SerializeField]
    private GameEvent rightButton1Event;
    [SerializeField]
    private GameEvent rightButton2Event;
    
    [Header("Cock thresholds")]
    [SerializeField]
    [Range(0f, 1f)]
    private float cockMinAxis;
    [SerializeField]
    [Range(-0.3f, -0.05f)]
    private float uncockMaxAxis;

    private bool cockingLeft = false;
    private bool cockingRight = false;

    private float lastYAxisLeft = 0f;
    private float lastYAxisRight = 0f;

    private void OnEnable()
    {
        if (leftController.Get() != null)
        {
            leftController.Get().TriggerPressed += ShotLeft;
            leftController.Get().TouchpadAxisChanged += CockLeft;
            leftController.Get().ButtonOnePressed += ReloadLeft;
            leftController.Get().ButtonTwoPressed += Button2Left;
        }

        if (rightController != null)
        {
            rightController.Get().TriggerPressed += ShotRight;
            rightController.Get().TouchpadAxisChanged += CockRight;
            rightController.Get().ButtonOnePressed += ReloadRight;
            rightController.Get().ButtonTwoPressed += Button2Right;
        }
    }

    private void OnDisable()
    {
        if (leftController != null)
        {
            leftController.Get().TriggerPressed -= ShotLeft;
            leftController.Get().TouchpadAxisChanged -= CockLeft;
            leftController.Get().ButtonOnePressed -= ReloadLeft;
            leftController.Get().ButtonTwoPressed -= Button2Left;
        }

        if (rightController != null)
        {
            rightController.Get().TriggerPressed -= ShotRight;
            rightController.Get().TouchpadAxisChanged -= CockRight;
            rightController.Get().ButtonOnePressed -= ReloadRight;
            rightController.Get().ButtonTwoPressed -= Button2Right;
        }
    }

    private void ReloadLeft(object sender, ControllerInteractionEventArgs e)
    {
        leftButton1Event.Raise();
    }

    private void ReloadRight(object sender, ControllerInteractionEventArgs e)
    {
        rightButton1Event.Raise();
    }

    private void CockLeft(object sender, ControllerInteractionEventArgs e)
    {
        if (e.touchpadAxis.y <= 0f)
        {
            float val = Mathf.Abs(e.touchpadAxis.y);
            if (lastYAxisLeft < val && val >= cockMinAxis && !cockingLeft)
            {
                cockingLeft = true;
                leftDownEvent.Raise();
            }
            lastYAxisLeft = val;
        }
        if (e.touchpadAxis.y >= uncockMaxAxis)
        {
            cockingLeft = false;
        }
    }

    private void CockRight(object sender, ControllerInteractionEventArgs e)
    {
        if (e.touchpadAxis.y <= 0f)
        {
            float val = Mathf.Abs(e.touchpadAxis.y);
            if (lastYAxisRight < val && val >= cockMinAxis && !cockingRight)
            {
                cockingRight = true;
                rightDownEvent.Raise();
            }
            lastYAxisRight = val;
        }
        if (e.touchpadAxis.y >= uncockMaxAxis)
        {
            cockingRight = false;
        }
    }

    private void ShotLeft(object sender, ControllerInteractionEventArgs e)
    {
        leftTriggerEvent.Raise();
    }

    private void ShotRight(object sender, ControllerInteractionEventArgs e)
    {
        rightTriggerEvent.Raise();
    }

    private void Button2Left(object sender, ControllerInteractionEventArgs e)
    {
        leftButton2Event.Raise();
    }

    private void Button2Right(object sender, ControllerInteractionEventArgs e)
    {
        rightButton2Event.Raise();
    }
}
