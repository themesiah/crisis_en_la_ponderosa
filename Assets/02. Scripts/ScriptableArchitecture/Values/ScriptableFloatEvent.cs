using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableFloatEvent : MonoBehaviour
{
    [System.Serializable]
    public class UnityTemplatedEvent : UnityEvent<float> { }
    [System.Serializable]
    public class UnityTemplatedEvent2 : UnityEvent<ScriptableFloat> { }
    [SerializeField]
    private UnityTemplatedEvent onValueChanged;
    [SerializeField]
    private UnityTemplatedEvent2 onValueChangedScriptable;
    [SerializeField]
    private ScriptableFloat valueReference;

    private void OnEnable()
    {
        valueReference.AddOnValueChangeCallback(OnValueChange);
    }

    private void OnDisable()
    {
        valueReference.RemoveOnValueChangeCallback(OnValueChange);
    }

    private void OnValueChange(float val)
    {
        onValueChanged.Invoke(val);
        onValueChangedScriptable.Invoke(valueReference);
    }
}