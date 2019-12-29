using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watch : MonoBehaviour
{
    [SerializeField]
    private ScriptableFloat zoneTimeReference;
    [SerializeField]
    private Image imageReference;

    private void OnEnable()
    {
        zoneTimeReference.AddOnValueChangeCallback(OnTimeValueChanged);
    }

    private void OnDisable()
    {
        zoneTimeReference.RemoveOnValueChangeCallback(OnTimeValueChanged);
    }

    private void OnTimeValueChanged(float newValue)
    {
        imageReference.fillAmount = newValue / zoneTimeReference.GetMax();
    }
}
