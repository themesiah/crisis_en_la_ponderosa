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

    [MenuItem("Snap2", menuItem = "Ponderosa/SnapToGroundBounds")]
    public static void SnapToGridBounds()
    {
        GameObject go = Selection.activeGameObject;
        RaycastHit hitInfo;
        if (Physics.Raycast(go.transform.position, Vector3.down, out hitInfo))
        {
            
            Collider c = go.GetComponent<Collider>();
            if (c)
            {
                float ysize = c.bounds.size.y;
                go.transform.position = hitInfo.point + Vector3.up * ysize/2f;
            } else
            {
                go.transform.position = hitInfo.point;
            }
        }
    }
}
