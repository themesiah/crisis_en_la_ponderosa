using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableValue/Float")]
public class ScriptableFloat : ScriptableValue<float>
{
    [SerializeField]
    private float MaxValue = 0f;
    [SerializeField]
    private float MinValue = -999f;

    public void IncrementValue(float increment)
    {
        Value += increment;
        if (MaxValue != 0f && Value > MaxValue)
        {
            Value = MaxValue;
        }
        if (MinValue != -999f && Value < MinValue)
        {
            Value = MinValue;
        }
        InvokeOnValueChange();
    }
}
