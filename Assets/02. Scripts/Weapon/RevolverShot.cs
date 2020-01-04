using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RevolverShot : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private GameObject impactPrefab;
    [SerializeField]
    private ScriptableInt ammoReference;
    [Header("Events")]
    [SerializeField]
    private UnityEvent onShot;
    [SerializeField]
    private UnityEvent onClick;
    [SerializeField]
    private UnityEvent onObstructed;
    [Header("Collision configuration")]
    [SerializeField]
    private float headRadius = 0.1f;
    [SerializeField]
    private float pistolRadius = 0.1f;
    [SerializeField]
    private LayerMask layerMask;

    public void Shot()
    {
        if (CheckPlayerColliding() || CheckPistolCollision(bulletSpawnPoint))
        {
            onObstructed.Invoke();
        } else if (ammoReference.GetValue() <= 0)
        {
            OnClick();
        } else {
            Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;
                GameObject impactPoint = Instantiate(impactPrefab);
                impactPoint.transform.position = pos;
                Destroy(impactPoint, 0.1f);
                IDamageable h = hit.collider.gameObject.GetComponent<IDamageable>();
                if (h != null)
                {
                    h.ReceiveHit(1);
                }
            }
            onShot.Invoke();
        }
    }

    public void OnClick()
    {
        onClick.Invoke();
    }

    private bool CheckPistolCollision(Transform source)
    {
        return Physics.CheckSphere(source.position, pistolRadius, layerMask);
    }

    private bool CheckPlayerColliding()
    {
        return Physics.CheckSphere(PlayerCollider.instance.transform.position, headRadius, layerMask);
    }
}
