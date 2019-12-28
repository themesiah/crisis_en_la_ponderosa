using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    [SerializeField]
    private float rate = 0.1f;
    void Update()
    {
        transform.localScale += Vector3.one * rate;
    }
}
