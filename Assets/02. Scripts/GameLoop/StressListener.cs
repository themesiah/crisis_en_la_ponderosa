using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class StressListener : MonoBehaviour
{
    [SerializeField]
    private ScriptableFloat stressReference;
    [SerializeField]
    private PostProcessProfile profile;
    [SerializeField]
    private PostProcessingManager postProcessingManager;

    StressPP stressSettings = null;

    private void Start()
    {
        stressReference.ResetValue();
    }

    private void OnEnable()
    {
        stressReference.AddOnValueChangeCallback(OnStressChanged);
    }

    private void OnDisable()
    {
        stressReference.RemoveOnValueChangeCallback(OnStressChanged);
        stressReference.ResetValue();
        OnStressChanged(0f);
    }

    private void OnStressChanged(float stress)
    {
        postProcessingManager.SetStress(stress);
    }
}
