using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressReduction : MonoBehaviour
{
    [SerializeField]
    private ScriptableFloat stressReference;
    [SerializeField]
    private float waitForStressReduction = 1f;
    [SerializeField]
    private float stressReductionPerSecond = 0.1f;

    private float lastStress;
    private bool currentlyReducing = true;
    private Coroutine waitForStressReductionCoroutine;

    private void Start()
    {
        lastStress = stressReference.GetValue();
    }

    private void OnStressChanged(float newStress)
    {
        if (newStress > lastStress)
        {
            WaitForStressReduction();
        }
    }

    private void WaitForStressReduction()
    {
        currentlyReducing = false;
        if (waitForStressReductionCoroutine != null)
        {
            StopCoroutine(waitForStressReductionCoroutine);
        }
        waitForStressReductionCoroutine = StartCoroutine(WaitForStressReductionCoroutine());
    }

    private IEnumerator WaitForStressReductionCoroutine()
    {
        yield return new WaitForSeconds(waitForStressReduction);
        currentlyReducing = true;
    }

    private void Update()
    {
        if (currentlyReducing)
        {
            stressReference.IncrementValue(-stressReductionPerSecond * Time.deltaTime);
        }
        lastStress = stressReference.GetValue();
    }

    private void OnEnable()
    {
        stressReference.AddOnValueChangeCallback(OnStressChanged);
    }

    private void OnDisable()
    {
        stressReference.RemoveOnValueChangeCallback(OnStressChanged);
    }
}
