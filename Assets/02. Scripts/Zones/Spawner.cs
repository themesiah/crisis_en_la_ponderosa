using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemyList {
    public List<OnDie> onDieList;
};

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<EnemyList> enemyLists;
    [SerializeField]
    private GameEvent zoneEnd;
    [SerializeField]
    private UnityEvent onAllEnemiesKilled;

    private int currentEnemiesTarget = 1;
    private int currentEnemiesKilled = 0;

    public void SpawnCurrentList()
    {
        currentEnemiesKilled = 0;
        currentEnemiesTarget = enemyLists[0].onDieList.Count;
        foreach (OnDie od in enemyLists[0].onDieList)
        {
            od.gameObject.SetActive(true);
            od.AddDieCallback(OnEnemyKilled);
        }
    }

    private void FinishCurrentList()
    {
        currentEnemiesKilled = 0;
        enemyLists.RemoveAt(0);
        if (enemyLists.Count == 0)
        {
            onAllEnemiesKilled.Invoke();
            zoneEnd.Raise();
        } else
        {
            SpawnCurrentList();
        }
    }

    private void OnEnemyKilled()
    {
        currentEnemiesKilled++;
        if (currentEnemiesKilled >= currentEnemiesTarget)
        {
            FinishCurrentList();
        }
    }
}
