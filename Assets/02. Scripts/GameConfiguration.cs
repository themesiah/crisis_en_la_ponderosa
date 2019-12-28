using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
    public static GameConfiguration instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}
