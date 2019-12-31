using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoints : MonoBehaviour
{
    [SerializeField]
    private ScriptableInt pointsReference;
    [SerializeField]
    private int pointsToWin;

    public void WinPoints()
    {
        pointsReference.IncrementValue(pointsToWin);
    }
}
