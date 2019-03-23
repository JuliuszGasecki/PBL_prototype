using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeMaterial : MonoBehaviour
{

    [SerializeField]
    private Transform[] heroes;
    [SerializeField]
    private List<RaycastHit> detectedObjects;
    [SerializeField]
    private Material transparentMaterial;

    private void Start()
    {
        detectedObjects = new List<RaycastHit>();
    }

    private void Update()
    {
        CheckRays();
    }

    private void CheckRays()
    {
        RaycastHit[] girlsHits;
        RaycastHit[] boizHits;
        Debug.DrawLine(heroes[0].position, transform.position, Color.blue, 0.1f);
        Debug.DrawLine(heroes[1].position, transform.position, Color.blue, 0.1f);
        girlsHits = Physics.RaycastAll(heroes[0].position, transform.position);
        boizHits = Physics.RaycastAll(heroes[1].position, transform.position);
        setOldMeterialToObjects(girlsHits);
        setOldMeterialToObjects(boizHits);
        foreach(RaycastHit hit in girlsHits)
        {
        if (hit.transform.GetComponent<MaterialChanger>() != null)
            {
                hit.transform.GetComponent<MaterialChanger>().UseNewMaterial(transparentMaterial);
                detectedObjects.Add(hit);
            }

        }

        foreach (RaycastHit hit in boizHits)
        {
            if (hit.transform.GetComponent<MaterialChanger>() != null)
            {
                hit.transform.GetComponent<MaterialChanger>().UseNewMaterial(transparentMaterial);
                detectedObjects.Add(hit);
            }

        }

    }

    private void setOldMeterialToObjects(RaycastHit[] hits)
    {
        List<RaycastHit> elementsToRemove = new List<RaycastHit>();
        if(detectedObjects != null)
        {
            foreach (RaycastHit hit in detectedObjects)
            {
                bool isInHits = false;
                for(int i = 0; i < hits.Length; i++)
                {
                    if (hit.transform.position.Equals(hits[i].transform.position))
                    {
                        isInHits = true;
                    }
                }
                if (!isInHits)
                {
                    Debug.Log(hit.transform.position);
                    elementsToRemove.Add(hit);
                }
            }
            foreach(RaycastHit elementToRemove in elementsToRemove)
            {
                elementToRemove.transform.GetComponent<MaterialChanger>().UseOldMaterial();
                detectedObjects.Remove(elementToRemove);

            }
        }  
    }
}
