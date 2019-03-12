using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRandomPath : FollowPath
{
    [SerializeField]
    private GameObject nextPathNode;
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
            }while(!canTurnBack && lastPathNodeName == newPathNode.name);
           
            nextPathNode = newPathNode;
        }

        move.Normalize();
        move.y = 0.0f;
        Move(move);
    }
    
}
