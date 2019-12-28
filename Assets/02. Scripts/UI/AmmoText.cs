using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    [SerializeField]
    private ScriptableInt ammoReference;
    [SerializeField]
    private Text textReference;
    
    private void OnEnable()
    {
        ammoReference.AddOnValueChangeCallback(OnAmmoValueChanged);
    }

    private void OnDisable()
    {
        ammoReference.RemoveOnValueChangeCallback(OnAmmoValueChanged);
    }

    private void OnAmmoValueChanged(int newValue)
    {
        textReference.text = newValue.ToString();
    }
}
