using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class StressVision : MonoBehaviour
{
    [SerializeField]
    private Transform enemyHeadPivot;
    [SerializeField]
    private ScriptableFloat stressPerSecondReference;
    [SerializeField]
    private ScriptableFloat stressPerTickReference;
    [SerializeField] [Tooltip("In seconds")] [Range(0.1f, 1f)]
    private float checkInterval = 0.5f;
    [SerializeField]
    private bool stressPerTick;
    [SerializeField]
    private bool activateStressIncreaseOnStart;
    [SerializeField]
    private ScriptableFloat stressReference;
    [SerializeField]
    private LayerMask layerMask;

    private bool stressIncreaseActive = false;
    private Coroutine stressCoroutine = null;


    void Start()
    {
        if (activateStressIncreaseOnStart)
        {
            ActivateStressVision();
        }
    }
    
    private IEnumerator StressVisionCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(checkInterval);
            StressTick();
        }
    }

    public void StressTick()
    {
        if (RaycastUtils.PlayerIsInVision(enemyHeadPivot, layerMask))
        {
            if (stressPerTick)
            {
                stressReference.IncrementValue(stressPerTickReference.GetValue());
            } else
            {
                stressReference.IncrementValue(stressPerSecondReference.GetValue() * checkInterval);
            }
        }
    }

    public void ActivateStressVision()
    {
        if (!stressIncreaseActive)
        {
            stressIncreaseActive = true;
            stressCoroutine = StartCoroutine(StressVisionCoroutine());
        }
    }

    public void DeactivateStressVision()
    {
        stressIncreaseActive = false;
        if (stressCoroutine != null)
        {
            StopCoroutine(stressCoroutine);
            stressCoroutine = null;
        }
    }

    public void OnEnable()
    {
        if (stressIncreaseActive)
        {
            ActivateStressVision();
        }
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
