using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    
    [SerializeField]
    private List<GameObject> nextPathNodes;
    [SerializeField]
    private List<int> nextPathNodesProbability;
    
    

    public GameObject RandNextPathNode()
    {
        return nextPathNodes[RandNextPathNodeIndex()];
    }

    private int RandNextPathNodeIndex()
    {        
        int rand = Random.Range(0, SumPathNodesProbability());
        int sum = 0;
        for (int i = 0; i < nextPathNodesProbability.Count; i++)
        {
            sum += nextPathNodesProbability[i];
            if (rand < sum)
            {
                return i;
            }
        }

        return -1;//never should happend

    }    

    private int SumPathNodesProbability()
    {
        int sum = 0;
        foreach (int probability in nextPathNodesProbability)
        {
            sum += probability;
        }

        return sum;
    }
}
