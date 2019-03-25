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
        RaycastHit[] girlsHits1;
        RaycastHit[] girlsHits2;
        RaycastHit[] boizHits;
        RaycastHit[] boizHits1;
        RaycastHit[] boizHits2;
        Debug.DrawRay(heroes[0].position, transform.position - heroes[0].position);
        Debug.DrawRay(heroes[1].position, transform.position - heroes[1].position);

        girlsHits = Physics.RaycastAll(heroes[0].position, transform.position - heroes[0].position);
        boizHits = Physics.RaycastAll(heroes[1].position, transform.position - heroes[1].position);

        {
            girlsHits1 = Physics.RaycastAll(new Vector3(heroes[0].position.x, heroes[0].position.y, heroes[0].position.z - 1f),  transform.position - heroes[0].position);
            girlsHits2 = Physics.RaycastAll(new Vector3(heroes[0].position.x, heroes[0].position.y, heroes[0].position.z + 1f),  transform.position - heroes[0].position);
            boizHits1 = Physics.RaycastAll(new Vector3(heroes[0].position.x, heroes[1].position.y, heroes[1].position.z - 1f),  transform.position - heroes[1].position);
            boizHits2 = Physics.RaycastAll(new Vector3(heroes[0].position.x, heroes[1].position.y, heroes[1].position.z + 1f),  transform.position - heroes[1].position);
        }
        setOldMeterialToObjects(girlsHits);
        setOldMeterialToObjects(girlsHits1);
        setOldMeterialToObjects(girlsHits2);
        setOldMeterialToObjects(boizHits);
        setOldMeterialToObjects(boizHits1);
        setOldMeterialToObjects(boizHits2);

        checkRaycastHit(girlsHits);
        checkRaycastHit(girlsHits1);
        checkRaycastHit(girlsHits2);
        checkRaycastHit(boizHits);
        checkRaycastHit(boizHits1);
        checkRaycastHit(boizHits2);
        

    }

    private void checkRaycastHit(RaycastHit[] Marek)
    {
        foreach (RaycastHit hit in Marek)
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
