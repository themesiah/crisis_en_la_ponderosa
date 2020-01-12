using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShotTrail : MonoBehaviour
{
    [SerializeField]
    private GameObject trailPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask raycastMask;

    public void SpawnTrail()
    {
        GameObject trailObject = Instantiate(trailPrefab);
        trailObject.transform.position = spawnPoint.position;
        trailObject.transform.rotation = spawnPoint.rotation;
        Vector3 endPosition = Vector3.zero;

        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, maxDistance, raycastMask))
        {
            endPosition = hit.point;
        } else
        {
            endPosition = spawnPoint.position + spawnPoint.forward * maxDistance;
        }

        ShotTrail shotTrail = trailObject.GetComponent<ShotTrail>();
        if (shotTrail != null)
        {
            shotTrail.InitializeTrail(endPosition);
        }
    }
}
