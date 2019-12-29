using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableValue<T> : ScriptableObject where T:System.IEquatable<T>
{
    [SerializeField]
    protected T Value;
    private UnityAction<T> onValueChange;

    [SerializeField]
    private T defaultValue;

    private T lastValue;

    public void SetValue(T newVal)
    {
        Value = newVal;
        InvokeOnValueChange();
    }

    public T GetValue()
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
}
