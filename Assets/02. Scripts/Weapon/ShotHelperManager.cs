using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHelperManager : MonoBehaviour
{
    [Header("General configuration")]
    [SerializeField]
    private Transform[] bulletSpawnPoints;
    [Header("Line parameters")]
    [SerializeField]
    private bool activateLine;
    [SerializeField]
    private Material lineMaterial;
    [SerializeField]
    private float distance = 50f;
    [SerializeField]
    private float width = 0.01f;
    [SerializeField]
    private Color lineColor = Color.magenta;

    [Header("Impact point parameters")]
    [SerializeField]
    private bool activateImpactPoint;
    [SerializeField]
    private GameObject impactPointPrefab;

    private LineRenderer[] lineRenderers;
    private GameObject[] impactPoints;

    void Start()
    {
        lineRenderers = new LineRenderer[bulletSpawnPoints.Length];
        impactPoints = new GameObject[bulletSpawnPoints.Length];
        for (int i = 0; i < bulletSpawnPoints.Length; ++i)
        {
            Transform t = bulletSpawnPoints[i];
            LineRenderer lr = t.gameObject.AddComponent<LineRenderer>();
            lineRenderers[i] = lr;
            lr.startColor = lineColor;
            lr.endColor = lineColor;
            lr.endWidth = width;
            lr.startWidth = width;
            lr.useWorldSpace = true;
            lr.positionCount = 2;
            lr.material = lineMaterial;
            lr.enabled = false;

            GameObject impactPoint = GameObject.Instantiate(impactPointPrefab);
            impactPoints[i] = impactPoint;
            impactPoint.SetActive(false);
        }
    }
    
    void Update()
    {
        for (int i = 0; i < bulletSpawnPoints.Length; ++i)
        {
            Transform t = bulletSpawnPoints[i];
            LineRenderer lr = lineRenderers[i];
            GameObject impactPoint = impactPoints[i];

            Ray ray = new Ray(t.position, t.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;

                if (activateLine)
                {
                    lr.SetPositions(new Vector3[2] { bulletSpawnPoints[i].position, pos });
                    lr.enabled = true;
                }
                else
                {
                    lr.enabled = false;
                }

                if (activateImpactPoint)
                {
                    impactPoint.SetActive(true);
                    impactPoint.transform.position = pos;
                }
                else
                {
                    impactPoint.SetActive(false);
                }
            }
            else
            {
                impactPoint.SetActive(false);

                if (activateLine)
                {
                    lr.SetPositions(new Vector3[2] { bulletSpawnPoints[i].position, bulletSpawnPoints[i].position + bulletSpawnPoints[i].forward * distance });
                } else
                {
                    lr.enabled = false;
                }
            }
        }
    }
}
