using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrail : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer trail;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool instant;

    private Vector3 endPosition;
    private bool started = false;

    public void InitializeTrail(Vector3 endPos)
    {
        endPosition = endPos;
        started = true;
    }
    
    void Update()
    {
        if (started)
        {
            if (instant)
            {
                transform.position = endPosition;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            }
            if (transform.position == endPosition)
            {
                DestroyTrail();
            }
        }
    }

    private void DestroyTrail()
    {
        Destroy(gameObject, trail.time);
    }
}
