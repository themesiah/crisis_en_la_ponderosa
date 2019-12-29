using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class StressVision : MonoBehaviour
{
    [SerializeField]
    private Transform enemyHeadPivot;
    [SerializeField]
    private float stressPerSecond = 0.01f;
    [SerializeField] [Tooltip("In seconds")] [Range(0.1f, 1f)]
    private float checkInterval = 0.5f;
    [SerializeField]
    private bool activateStressIncreaseOnStart;
    [SerializeField]
    private ScriptableFloat stressReference;

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
            if (RaycastUtils.PlayerIsInVision(enemyHeadPivot))
            {
                stressReference.IncrementValue(stressPerSecond * checkInterval);
            }
        }
    }

    public void ActivateStressVision()
    {
        stressIncreaseActive = true;
        stressCoroutine = StartCoroutine(StressVisionCoroutine());
    }

    public void DeactivateStressVision()
    {
        stressIncreaseActive = false;
        if (stressCoroutine != null)
        {
            StopCoroutine(stressCoroutine);
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
