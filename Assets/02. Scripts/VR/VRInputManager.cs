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
    private GameEvent leftButton1EventKeep;
    [SerializeField]
    private GameEvent leftButton2Event;
    [SerializeField]
    private GameEvent rightTriggerEvent;
    [SerializeField]
    private GameEvent rightDownEvent;
    [SerializeField]
    private GameEvent rightButton1Event;
    [SerializeField]
    private GameEvent rightButton1EventKeep;
    [SerializeField]
    private GameEvent rightButton2Event;
    
    [Header("Cock thresholds")]
    [SerializeField]
    [Range(0f, 1f)]
    private float cockMinAxis;
    [SerializeField]
    [Range(-0.3f, -0.05f)]
    private float uncockMaxAxis;

    [Header("Keep pressing parameters")]
    [SerializeField]
    private float timeToTeleport = 1f;

    private bool cockingLeft = false;
    private bool cockingRight = false;

    // Keep pressing variables
    private bool button1leftPressed = false;
    private float button1leftPressedTime = 0f;
    private bool button1rightPressed = false;
    private float button1rightPressedTime = 0f;

    private float lastYAxisLeft = 0f;
    private float lastYAxisRight = 0f;

    private void OnEnable()
    {
        if (leftController.Get() != null)
        {
            leftController.Get().TriggerPressed += TriggerLeft;
            leftController.Get().TouchpadAxisChanged += StickDownLeft;
            leftController.Get().ButtonOnePressed += Button1Left;
            leftController.Get().ButtonOneReleased += Button1LeftRelease;
            leftController.Get().ButtonTwoPressed += Button2Left;
        }

        if (rightController != null)
        {
            rightController.Get().TriggerPressed += TriggerRight;
            rightController.Get().TouchpadAxisChanged += StickDownRight;
            rightController.Get().ButtonOnePressed += Button1Right;
            rightController.Get().ButtonOneReleased += Button1RightRelease;
            rightController.Get().ButtonTwoPressed += Button2Right;
        }
    }

    private void OnDisable()
    {
        if (leftController != null)
        {
            leftController.Get().TriggerPressed -= TriggerLeft;
            leftController.Get().TouchpadAxisChanged -= StickDownLeft;
            leftController.Get().ButtonOnePressed -= Button1Left;
            leftController.Get().ButtonOneReleased -= Button1LeftRelease;
            leftController.Get().ButtonTwoPressed -= Button2Left;
        }

        if (rightController != null)
        {
            rightController.Get().TriggerPressed -= TriggerRight;
            rightController.Get().TouchpadAxisChanged -= StickDownRight;
            rightController.Get().ButtonOnePressed -= Button1Right;
            rightController.Get().ButtonOneReleased -= Button1RightRelease;
            rightController.Get().ButtonTwoPressed -= Button2Right;
        }
    }

    private void Update()
    {
        if (button1leftPressed)
        {
            button1leftPressedTime += Time.deltaTime;
            if (button1leftPressedTime >= timeToTeleport)
            {
                leftButton1EventKeep.Raise();
                button1leftPressedTime = 0f;
                button1leftPressed = false;
            }
        } else
        {
            button1leftPressedTime = 0f;
        }
        if (button1rightPressed)
        {
            button1rightPressedTime += Time.deltaTime;
            if (button1rightPressedTime >= timeToTeleport)
            {
                rightButton1EventKeep.Raise();
                button1rightPressedTime = 0f;
                button1rightPressed = false;
            }
        } else
        {
            button1rightPressedTime = 0f;
        }
    }

    private void Button1Left(object sender, ControllerInteractionEventArgs e)
    {
        leftButton1Event.Raise();
        button1leftPressed = true;
    }

    private void Button1Right(object sender, ControllerInteractionEventArgs e)
    {
        rightButton1Event.Raise();
        button1rightPressed = true;
    }

    private void Button1LeftRelease(object sender, ControllerInteractionEventArgs e)
    {
        button1leftPressed = false;
    }

    private void Button1RightRelease(object sender, ControllerInteractionEventArgs e)
    {
        button1rightPressed = false;
    }

    private void StickDownLeft(object sender, ControllerInteractionEventArgs e)
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

    private void StickDownRight(object sender, ControllerInteractionEventArgs e)
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

    private void TriggerLeft(object sender, ControllerInteractionEventArgs e)
    {
        leftTriggerEvent.Raise();
    }

    private void TriggerRight(object sender, ControllerInteractionEventArgs e)
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
