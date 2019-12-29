using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RaycastUtils
{
    public static bool PlayerIsInVision(Transform origin)
    {
        Transform playerHead = VRTK_DeviceFinder.HeadsetTransform();
        if (playerHead == null)
        {
            return false;
        }
        RaycastHit hitInfo;
        Vector3 between = (playerHead.position - origin.position);
        if (Physics.Raycast(origin.position, between.normalized, out hitInfo, between.magnitude)) // If it collides, it's because it doesn't see the player. The player IS NOT a collider.
        {
            return false;
        }
        return true;
    }
}
