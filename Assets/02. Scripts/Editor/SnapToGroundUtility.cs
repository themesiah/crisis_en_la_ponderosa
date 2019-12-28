using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SnapToGroundUtility
{
    [MenuItem("Snap", menuItem = "Ponderosa/SnapToGround")]
    public static void SnapToGrid()
    {
        GameObject go = Selection.activeGameObject;
        RaycastHit hitInfo;
        if (Physics.Raycast(go.transform.position, Vector3.down, out hitInfo))
        {
            go.transform.position = hitInfo.point;
        }
    }
}
