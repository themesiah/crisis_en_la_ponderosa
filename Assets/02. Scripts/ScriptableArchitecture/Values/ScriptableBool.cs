using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableValue/Bool")]
public class ScriptableBool : ScriptableValue<bool>
{
    public void Switch()
    {
        Value = !Value;
    }
}
