using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFallColliderTriggerManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FallCollider")
        {
            Debug.Log("Enter Fall Collider");
            transform.parent.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FallCollider")
        {
            Debug.Log("Exit Fall Collider");
            transform.parent.GetComponent<BoxCollider>().enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FallCollider")
        {
            Debug.Log("Stay Fall Collider");
            transform.parent.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
