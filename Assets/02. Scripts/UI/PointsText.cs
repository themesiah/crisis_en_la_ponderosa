using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsText : MonoBehaviour
{
    [SerializeField]
    private ScriptableInt pointsReference;
    [SerializeField]
    private Text textReference;
    [SerializeField]
    private string textBase;

    private void Start()
    {
        OnPointsChanged(pointsReference.GetValue());
    }

    private void OnEnable()
    {
        pointsReference.AddOnValueChangeCallback(OnPointsChanged);
    }

    private void OnDisable()
    {
        pointsReference.RemoveOnValueChangeCallback(OnPointsChanged);
    }

    private void OnPointsChanged(int newPoints)
    {
        textReference.text = string.Format(textBase, newPoints);
    }
}
