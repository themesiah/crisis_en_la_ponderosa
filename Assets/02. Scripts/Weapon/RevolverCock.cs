using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RevolverCock : MonoBehaviour
{
    [SerializeField]
    private GameObject helperObjectInstance;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private UnityEvent onCock;

    private GameObject helperObject;
    private bool cocked;

    private void Start()
    {
        helperObject = GameObject.Instantiate(helperObjectInstance);
        helperObject.SetActive(false);
    }

    public void Cock()
    {
        if (!cocked)
        {
            cocked = true;
            onCock.Invoke();
            ChangeHelperObjectStatus(false);
        }
    }

    public void ResetCock()
    {
        cocked = false;
        ChangeHelperObjectStatus(false);
    }

    private void ChangeHelperObjectStatus(bool forceDeactivate)
    {
        if (forceDeactivate)
        {
            helperObject.SetActive(false);
        }
        else
        {
            helperObject.SetActive(cocked);
        }
    }

    private void Update()
    {
        if (cocked)
        {
            Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ChangeHelperObjectStatus(false);
                helperObject.transform.position = hit.point;
            }
            else
            {
                ChangeHelperObjectStatus(true);
            }
        }
    }
}
