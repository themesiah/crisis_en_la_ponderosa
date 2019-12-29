using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="SetManager", menuName = "Utils/SetManager", order = 0)]
public class SetUtils : ScriptableObject
{
    public void DeactivateAllEnemyShot(RuntimeSetEnemyShot rses)
    {
        foreach(EnemyShot es in rses.Items)
        {
            es.StopShooting();
        }
    }

    public void DeactivateAllStressVision(RuntimeSetStressVision rssv)
    {
        foreach (StressVision sv in rssv.Items)
        {
            sv.DeactivateStressVision();
        }
    }
}
