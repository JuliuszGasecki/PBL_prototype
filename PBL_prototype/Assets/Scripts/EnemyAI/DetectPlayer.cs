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
    [SerializeField]
    private Texture texture;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in players)
        {
            if(IsSeen(player, detectionDistance)){
                Debug.Log("Wykryto " + player.name);
            }
        }
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

          //  Gizmos.color = Color.blue;
          //  Gizmos.DrawRay(transform.position, transform.forward * detectionDistance);
        }
    }

    public bool IsSeen(GameObject obj, float maxDetectionDistance)
    {
        Hide hide = obj.GetComponent<Hide>();
        if (hide!= null && hide.IsObjectHidden())
        {
            return false;
        }
        Vector3 direction = (obj.transform.position - transform.position).normalized;
        float angle = Vector3.Angle(gameObject.transform.forward, direction);
       // Debug.Log(angle);
        if(angle > viewAngle)
        {
            return false;
        }
        RaycastHit raycastHit = new RaycastHit();
        bool rayHitted = Physics.Raycast(transform.position, direction, out raycastHit, maxDetectionDistance);
       
        if (!rayHitted || raycastHit.collider.gameObject.name != obj.name)
        {
            return false;
        }
        return true;
    }

    private void OnGUI()
    {
        foreach (GameObject player in players)
        {
            if (IsSeen(player, detectionDistance))
            {
                Rect rect = new Rect(0, 0, Screen.width/2, Screen.height/2);
                GUI.DrawTexture(rect,texture);
            }
        }
        
    }
}
