using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableValue/FloatValueSelector")]
public class ScritpableFloatValueSelector : ScriptableFloat
{
    [SerializeField]
    private List<ScriptableFloat> listOfValues;
    [SerializeField]
    private ScriptableInt valueToGetReference;

    public override float GetValue()
    {
        int index = valueToGetReference.GetValue();
        float value = defaultValue;
        if (listOfValues.Count > index)
        {
            value = listOfValues[valueToGetReference.GetValue()].GetValue();
        }
        return value;
    }
}
