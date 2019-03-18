using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpecificPath : FollowPath
{
    [SerializeField] private List<GameObject> pathNodes;
    public GameObject Point;
    private int currentNodeIndex;
    public bool IsTrigger;
    private Vector3 _lastPosition;
    public Vector3 RockPosition;
    private GameObject _rockObject;
    private GameObject _lastPositionObject;
    private int _countChangesNodes;
    private bool _canCount;
    private int _tempIndex;
    private int _tempIndex2;

    // Start is called before the first frame update
    void Start()
    {
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
                RemoveNodes();
            }
            else
            {
                currentNodeIndex = 0;
                RemoveNodes();
            }
        }

        move.Normalize();
        move.y = 0.0f;

        this.Move(move);
    }

    void RemoveNodes()
    {
        if (_countChangesNodes == 1 && _canCount)
        {
            pathNodes.Remove(_rockObject);
            pathNodes.Remove(_lastPositionObject);
            Destroy(_rockObject);
            Destroy(_lastPositionObject);
            currentNodeIndex = _tempIndex;
        }

        if (_countChangesNodes == 2)
        {
            _canCount = false;
        }

        if (_canCount)
            _countChangesNodes++;
    }

    void ChangeDestiny()
    {
        if (IsTrigger)
        {
            _lastPosition = transform.position;
            _tempIndex = currentNodeIndex;
            CreateNewNodes();
            InsertNewNodes();
            _countChangesNodes = 0;
            _canCount = true;
            IsTrigger = false;
        }
    }

    void CreateNewNodes()
    {
        _rockObject = Instantiate(Point) as GameObject;
        _rockObject.transform.position = RockPosition;
        _lastPositionObject = Instantiate(Point) as GameObject;
        _lastPositionObject.transform.position = _lastPosition;
    }

    void InsertNewNodes()
    {
        pathNodes.Insert(currentNodeIndex, _rockObject);
        int tempIndex = currentNodeIndex;
        tempIndex++;
        if (tempIndex > pathNodes.Count - 1)
            tempIndex = 0;
        pathNodes.Insert(tempIndex, _lastPositionObject);
    }
}