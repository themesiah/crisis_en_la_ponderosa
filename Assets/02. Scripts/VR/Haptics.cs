using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Haptics : MonoBehaviour
{
    [SerializeField]
    private ScriptableBool vibrationReference;
    [SerializeField]
    private AudioClip vibrationClip;
    [SerializeField]
    private float angleThreshold = 15f;

    public void Vibrate(object source)
    {
        if (!vibrationReference.GetValue())
            return;
        Transform playerHead = VRTK_DeviceFinder.HeadsetTransform();
        bool[] blend = GetBlend((Vector3)source, playerHead);
        
        VRTK_ControllerReference reference_left = VRTK_ControllerReference.GetControllerReference((uint)0);
        VRTK_ControllerReference reference_right = VRTK_ControllerReference.GetControllerReference((uint)1);
        if (blend[0])
        {
            VRTK_ControllerHaptics.TriggerHapticPulse(reference_left, vibrationClip);
        }
        if (blend[1])
        {
            VRTK_ControllerHaptics.TriggerHapticPulse(reference_right, vibrationClip);
        }
    }

    private bool[] GetBlend(Vector3 source, Transform playerHead)
    {
        bool[] blend = new bool[2];
        Vector3 forward = playerHead.forward;
        forward.y = 0f;
        Vector3 dir = (source - playerHead.position);
        dir.y = 0f;
        float angle = Vector3.SignedAngle(forward, dir, Vector3.up);
        if (angle < 0f)
        {
            angle = 360f + angle;
        }

        if (!(angle > angleThreshold && angle < 180f - angleThreshold))
        {
            blend[0] = true;
        }
        if (!(angle < 360f - angleThreshold && angle > 180f + angleThreshold))
        {
            blend[1] = true;
        }


        /*float convertedAngle = (angle + 90f) % 360f;
        float normalized = Mathf.PingPong(convertedAngle, 180f);
        float blendLeft = Mathf.InverseLerp(0f, 180f, normalized);*/

        return blend;
    }
}
