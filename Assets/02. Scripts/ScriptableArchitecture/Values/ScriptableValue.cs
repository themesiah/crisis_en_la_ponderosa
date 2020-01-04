using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScriptableValue<T> : ScriptableObject where T:System.IEquatable<T>
{
    [SerializeField]
    protected T Value;
    private UnityAction<T> onValueChange;

    [SerializeField]
    protected T defaultValue;

    private T lastValue;

    public void SetValue(T newVal)
    {
        Value = newVal;
        InvokeOnValueChange();
    }

    public virtual T GetValue()
    {
        return Value;
    }

    public void ResetValue()
    {
        Value = defaultValue;
        InvokeOnValueChange();
    }

    public void AddOnValueChangeCallback(UnityAction<T> action)
    {
        onValueChange += action;
    }

    public void RemoveOnValueChangeCallback(UnityAction<T> action)
    {
        onValueChange -= action;
    }

    public void InvokeOnValueChange()
    {
        if (onValueChange != null && !lastValue.Equals(Value))
        {
            onValueChange(Value);
            lastValue = Value;
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (EditorApplication.isPlaying)
        {
            InvokeOnValueChange();
        }
    }
#endif
}
