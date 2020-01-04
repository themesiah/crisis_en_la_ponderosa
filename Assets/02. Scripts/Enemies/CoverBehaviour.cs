using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoverBehaviour : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onCover;
    [SerializeField]
    private UnityEvent commonCoverEvent;
    [SerializeField]
    private UnityEvent onUncover;
    [SerializeField]
    private Vector2 minMaxTimeToUncover;
    [SerializeField]
    private Vector2 minMaxTimeToCover;
    [SerializeField]
    private bool coveredOnStart = true;

    private void Start()
    {
        if (coveredOnStart)
        {
            DoUncover();
            commonCoverEvent.Invoke();
        } else
        {
            DoCover();
        }
    }

    public void DoCover()
    {
        if (this.isActiveAndEnabled)
        {
            StartCoroutine(CrouchCoroutine());
        }
    }

    public void DoUncover()
    {
        if (this.isActiveAndEnabled)
        {
            StartCoroutine(StandCoroutine());
        }
    }

    private IEnumerator CrouchCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(minMaxTimeToCover.x, minMaxTimeToCover.y));
        onCover.Invoke();
        commonCoverEvent.Invoke();
    }

    private IEnumerator StandCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(minMaxTimeToUncover.x, minMaxTimeToUncover.y));
        onUncover.Invoke();
    }
}
