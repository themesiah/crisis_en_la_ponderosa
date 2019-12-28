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
            if (IsInVision())
            {
                stressReference.IncrementValue(stressPerSecond * checkInterval);
            }
        }
    }

    private bool IsInVision()
    {
        Transform playerHead = VRTK_DeviceFinder.HeadsetTransform();
        if (playerHead == null)
        {
            return false;
        }
        RaycastHit hitInfo;
        Vector3 between = (playerHead.position - enemyHeadPivot.position);
        if (Physics.Raycast(enemyHeadPivot.position, between.normalized, out hitInfo, between.magnitude)) // If it collides, it's because it doesn't see the player. The player IS NOT a collider.
        {
            return false;
        }
        return true;
    }

    public void ActivateStressVision()
    {
        stressIncreaseActive = true;
        stressCoroutine = StartCoroutine(StressVisionCoroutine());
    }

    public void DeactivateStressVision()
    {
        stressIncreaseActive = false;
        StopCoroutine(stressCoroutine);
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
