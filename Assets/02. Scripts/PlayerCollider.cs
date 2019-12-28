using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public static PlayerCollider instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
