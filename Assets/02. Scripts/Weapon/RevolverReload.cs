using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RevolverReload : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private ScriptableInt ammoReference;
    [Header("Parameters")]
    [SerializeField]
    private float timePerBullet = 0.1f;
    [Header("Events")]
    [SerializeField]
    private UnityEvent onStartReload;
    [SerializeField]
    private UnityEvent onReloadOne;
    [SerializeField]
    private UnityEvent onFinishReload;
    
    void Start()
    {
        ammoReference.ResetValue();
    }

    public void StartReload()
    {
        if (!ammoReference.IsMax())
        {
            onStartReload.Invoke();
        }
        StartCoroutine(ReloadOne());
    }

    private IEnumerator ReloadOne()
    {
        while (!ammoReference.IsMax())
        {
            yield return new WaitForSeconds(timePerBullet);
            onReloadOne.Invoke();
        }
        onFinishReload.Invoke();
    }
}
