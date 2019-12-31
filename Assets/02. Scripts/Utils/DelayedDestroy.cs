using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    [SerializeField][Tooltip("Default: The attached game object")]
    private GameObject objectToDestroy;
    [SerializeField]
    private float timeToDestroy = 1f;

    public void DoDestroy()
    {
        if (objectToDestroy == null)
        {
            objectToDestroy = gameObject;
        }
        Destroy(objectToDestroy, timeToDestroy);
    }
}
