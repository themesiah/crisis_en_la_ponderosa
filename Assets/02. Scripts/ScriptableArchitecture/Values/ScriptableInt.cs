using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableValue/Int")]
public class ScriptableInt : ScriptableValue<int>
{
    [SerializeField]
    private int MaxValue = 0;

    public void IncrementValue(int increment)
    {
        Value += increment;
        if (MaxValue != 0 && Value > MaxValue)
        {
            Value = MaxValue;
        }
        InvokeOnValueChange();
    }

    public bool IsMax()
    {
        return MaxValue == 0 || Value >= MaxValue;
    }
}
