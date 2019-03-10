using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> players;
    [SerializeField]
    private float detectionDistance;
    [SerializeField]
    private float viewAngle;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
               
    }

    //For debuging
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
        foreach (GameObject player in players)
        {
            if(IsSeen(player, detectionDistance))
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }

            Gizmos.DrawRay(transform.position, player.transform.position - transform.position);

        }
    }

    public bool IsSeen(GameObject obj, float maxDetectionDistance)
    {
        Vector3 direction = (obj.transform.position - transform.position).normalized;
        RaycastHit raycastHit = new RaycastHit();
        bool rayHitted = Physics.Raycast(transform.position, direction, out raycastHit, maxDetectionDistance);
       
        if (!rayHitted || raycastHit.collider.gameObject.name != obj.name)
        {
            return false;
        }
        return true;
    }
}
