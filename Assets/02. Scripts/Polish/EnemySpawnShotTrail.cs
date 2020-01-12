using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EnemySpawnShotTrail : MonoBehaviour
{
    [SerializeField]
    private GameObject trailPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float randomFactor = 1f;

    public void SpawnTrail()
    {
        GameObject trailObject = Instantiate(trailPrefab);
        trailObject.transform.position = spawnPoint.position;
        trailObject.transform.rotation = spawnPoint.rotation;

        Transform playerHead = VRTK_DeviceFinder.HeadsetTransform();
        Vector3 endPosition = playerHead.position;

        endPosition += Random.insideUnitSphere * randomFactor;

        ShotTrail shotTrail = trailObject.GetComponent<ShotTrail>();
        if (shotTrail != null)
        {
            shotTrail.InitializeTrail(endPosition);
        }
    }
}
