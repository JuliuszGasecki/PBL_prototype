using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpecificPath : FollowPath
{
    [SerializeField] private List<GameObject> pathNodes;
    private int currentNodeIndex;
    public bool IsTrigger;
    private Vector3 _lastPosition;
    public Vector3 RockPosition;
    private Transform tempCurrentNodeP;
    private Transform tempNextNodeP;
    private Transform tempLastNodeP;
    private int _countChangesNodes;

    private int _tempIndex;

    // Start is called before the first frame update
    void Start()
    {
        _countChangesNodes = 3;
        currentNodeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDestiny();
        Vector3 move = pathNodes[currentNodeIndex].transform.position - transform.position;
        if (Mathf.Sqrt(move.x * move.x + move.z * move.z) < maxNodeDistance)
        {
            if (currentNodeIndex < pathNodes.Count - 1)
            {
                currentNodeIndex++;
                ChangeNextPoint();
            }
            else
            {
                currentNodeIndex = 0;
                ChangeNextPoint();
            }
        }

        move.Normalize();
        move.y = 0.0f;

        this.Move(move);
    }

    void ChangeNextPoint()
    {
        if (_countChangesNodes == 0)
        {
            pathNodes[_tempIndex].transform.position = tempCurrentNodeP.position;
            pathNodes[currentNodeIndex].transform.position = _lastPosition;
            _tempIndex = currentNodeIndex;
        }

        if (_countChangesNodes == 1)
        {
            pathNodes[_tempIndex].transform.position = tempNextNodeP.position;
            _tempIndex = currentNodeIndex;
        }

        _countChangesNodes++;
    }
    void ChangeDestiny()
    {
        if (IsTrigger)
        {
            _lastPosition = transform.position;
            _tempIndex = currentNodeIndex;
            SavePositions(_tempIndex);
            pathNodes[currentNodeIndex].transform.position = RockPosition;
            _countChangesNodes = 0;
            IsTrigger = false;
        }
    }

    void SavePositions(int index)
    {
        tempCurrentNodeP = pathNodes[index].transform;
        if (index + 1 > pathNodes.Count - 1)
        {
            index = 0;
        }
        tempNextNodeP = pathNodes[index + 1].transform;
    }
}