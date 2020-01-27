using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu(fileName = "GameUtilitiesManager", menuName = "Managers/GameUtilities", order = 0)]
public class GameUtilitiesManager : ScriptableObject
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Exit();
#endif
    }
}
