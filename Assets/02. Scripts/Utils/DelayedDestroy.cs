using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    [SerializeField][Tooltip("Default: The attached game object")]
    private GameObject objectToDestroy;

    public void DoDestroy(float timeToDestroy)
    {
        if (objectToDestroy == null)
        {
            objectToDestroy = gameObject;
        }
        Destroy(objectToDestroy, timeToDestroy);
    }
}
