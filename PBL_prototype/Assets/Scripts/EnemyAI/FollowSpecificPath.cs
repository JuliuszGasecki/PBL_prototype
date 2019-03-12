using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpecificPath : FollowPath
{
    [SerializeField]
    private List<GameObject> pathNodes;
    private int currentNodeIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentNodeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = pathNodes[currentNodeIndex].transform.position - transform.position;
        if(Mathf.Sqrt(move.x * move.x + move.z * move.z) < maxNodeDistance)
        {
            if(currentNodeIndex < pathNodes.Count - 1)
            {
                currentNodeIndex++;
            }
            else
            {
                currentNodeIndex = 0;
            }
        }
        
        move.Normalize();
        move.y = 0.0f;

        this.Move(move);
    }

    
}
