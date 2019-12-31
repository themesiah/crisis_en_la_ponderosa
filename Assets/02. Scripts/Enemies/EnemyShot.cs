using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShot : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private bool startShootingOnStart;
    [SerializeField]
    private Vector2 minMaxShotingInterval;
    [Header("References")]
    [SerializeField]
    private ScriptableFloat stressReference;
    [SerializeField]
    private Transform enemyHeadPivot;
    [Header("Events")]
    [SerializeField]
    private UnityEvent onStartShot;
    [SerializeField]
    private UnityEvent onShot;
    [SerializeField]
    private GameEvent playerLoseEvent;
    [SerializeField]
    private LayerMask layerMask;
    

    private bool shooting;
    private Coroutine shotCoroutine;

    private void Start()
    {
        if (startShootingOnStart)
        {
            StartShooting();
        }
    }

    public void StartShooting()
    {
        if (shooting)
        {
            StopCoroutine(shotCoroutine);
        }
        shotCoroutine = StartCoroutine(ShotCoroutine());
    }

    public void StopShooting()
    {
        if (shooting)
        {
            StopCoroutine(shotCoroutine);
        }
        shooting = false;
    }

    private IEnumerator ShotCoroutine()
    {
        shooting = true;
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minMaxShotingInterval.x, minMaxShotingInterval.y));
            OnStartShot();
        }
    }

    private void OnStartShot()
    {
        onStartShot.Invoke();
    }

    public void OnShot()
    {
        onShot.Invoke();
        if (RaycastUtils.PlayerIsInVision(enemyHeadPivot, layerMask) && stressReference.IsMax())
        {
            playerLoseEvent.Raise();
        }
    }

    private void OnEnable()
    {
        if (shooting)
        {
            StartShooting();
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
