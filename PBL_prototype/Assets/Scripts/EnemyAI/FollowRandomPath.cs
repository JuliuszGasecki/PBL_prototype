using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRandomPath : MonoBehaviour
{
    [SerializeField]
    private GameObject nextPathNode;
    [SerializeField]
    private float maxNodeDistance;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool canTurnBack;
    private string lastPathNodeName;
    private string currentNodeName;

    // Start is called before the first frame update
    void Start()
    {
        lastPathNodeName = null;
        currentNodeName = null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = nextPathNode.transform.position - transform.position;
        if(Mathf.Sqrt(move.x * move.x + move.z * move.z) < maxNodeDistance)
        {
            lastPathNodeName = currentNodeName;
            currentNodeName = nextPathNode.name;
            GameObject newPathNode;
            do
            {
                newPathNode = nextPathNode.GetComponent<PathNode>().RandNextPathNode();
                Debug.Log(lastPathNodeName + " " + newPathNode.name);
            }while(!canTurnBack && lastPathNodeName == newPathNode.name);
           
            nextPathNode = newPathNode;
        }
        
        move.Normalize();

        transform.Translate(move.x * speed * Time.deltaTime, 0f, move.z * speed * Time.deltaTime);
    }

    
}
