using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu(fileName = "EditorUtilitiesManager", menuName = "Managers/EditorUtilities", order = 0)]
public class EditorUtilitiesManager : ScriptableObject
{
    public void PlayModeStop()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
