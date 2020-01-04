using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRevolverController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onShot;
    [SerializeField]
    private UnityEvent onFail;
    [SerializeField]
    private UnityEvent onReload;
    [SerializeField]
    private UnityEvent onCock;

    private bool revolverActive;
    private bool reloading = false;
    private bool canShot = true;

    private void OnEnable()
    {
        revolverActive = true;
    }

    private void OnDisable()
    {
        revolverActive = false;
    }

    public void SetCanShot(bool can)
    {
        canShot = can;
    }

    public void Shot()
    {
        if (revolverActive && !reloading && canShot)
        {
            onShot.Invoke();
        } else if (!canShot)
        {
            onFail.Invoke();
        }
    }

    public void Reload()
    {
        if (revolverActive && !reloading)
        {
            onReload.Invoke();
        }
    }

    public void Cock()
    {
        if (revolverActive)
        {
            onCock.Invoke();
        }
    }

    public bool IsActive()
    {
        return revolverActive;
    }

    public void SetReloading(bool rel)
    {
        reloading = rel;
    }
}
