using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRTK_AvatarHandController_Extension : VRTK_AvatarHandController
{
    [SerializeField]
    private Vector3 mirrorRotation;
    [SerializeField]
    private Vector3 mirrorOffset;

    protected override void MirrorHand()
    {
        Transform modelTransform = (handModel != null ? handModel : transform.Find("Model"));
        if (modelTransform != null)
        {
            // Scale
            modelTransform.localScale = new Vector3(modelTransform.localScale.x * -1f, modelTransform.localScale.y, modelTransform.localScale.z);
            // Rotation
            Vector3 euler = modelTransform.localRotation.eulerAngles;
            euler.x += mirrorRotation.x;
            euler.y += mirrorRotation.y;
            euler.z += mirrorRotation.z;
            modelTransform.localRotation = Quaternion.Euler(euler);
            // Position
            modelTransform.Translate(mirrorOffset);
        }
    }
}
