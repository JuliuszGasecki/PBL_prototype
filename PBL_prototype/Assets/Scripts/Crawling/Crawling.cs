using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawling : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> teleportPoints = new List<GameObject>();
    [SerializeField]
    private float crawlingTime = 1.5f;
    private GameObject girl;
    float time = 0;
    private bool isCrawling;
    private void Start()
    {
        girl = GameObject.Find("Girl");
        isCrawling = false;
    }
    private void Update()
    {
        int pointsValue = checkIfStarts();
        if(pointsValue != -1 && !isCrawling)
        {
            Crawle(pointsValue);
            isCrawling = true;
        }
        if (isCrawling)
        {
            girl.GetComponent<ControlByWSAD>().blockControlls();
            foreach(MeshRenderer m in girl.GetComponentsInChildren<MeshRenderer>())
            {
                m.enabled = false;
            }
        }
        else
        {
            foreach (MeshRenderer m in girl.GetComponentsInChildren<MeshRenderer>())
            {
                m.enabled = true;
            }
        }
        if(Time.time - time > crawlingTime && isCrawling)
        {
            girl.GetComponent<ControlByWSAD>().freeControlls();
            isCrawling = false;
        }
    }

    private int checkIfStarts()
    {
        if (teleportPoints[0].GetComponent<InformCrawling>().isStartPoint)
        {
            return 0;
        }
        else if (teleportPoints[1].GetComponent<InformCrawling>().isStartPoint)
        {
            return 1;
        }
        else return -1;
    }

    public void Crawle(int ID)
    {
        if(ID == 1)
        {
            Vector3 girlOffset = CalculateVectorBetweenPoints(teleportPoints[0].transform, teleportPoints[1].transform);
            CalculateGirlPosition(girlOffset);
        }
        else
        {
            Vector3 girlOffset = CalculateVectorBetweenPoints(teleportPoints[1].transform, teleportPoints[0].transform);
            CalculateGirlPosition(girlOffset);
        }
        time = Time.time;
    }

    private Vector3 CalculateVectorBetweenPoints(Transform startPoint, Transform endPoint)
    {
        Vector3 calculatedVector = new Vector3(
            startPoint.position.x - endPoint.position.x,
            startPoint.position.y - endPoint.position.y,
            startPoint.position.z - endPoint.position.z
            );
        Debug.Log(calculatedVector.x + " " + calculatedVector.y + " " + calculatedVector.z);
        return calculatedVector;
    }

    private void CalculateGirlPosition(Vector3 offset)
    {
        Debug.Log(
            "new coords" +
            girl.transform.position.x + offset.z + " ," +
            girl.transform.position.y + offset.y + " ," +
            girl.transform.position.z + offset.x + " ," );
        girl.transform.position = new Vector3(
            girl.transform.position.x + offset.x,
            girl.transform.position.y + offset.y,
            girl.transform.position.z + offset.z);
    }

}
