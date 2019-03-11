using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisionMenager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> colliders;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BoxController>().selectedStrategy == "ClimbBox")
        {
            foreach(GameObject g in colliders)
            {
                g.GetComponent<BoxCollider>().enabled = true;
            }
        }
        else
        {
            foreach (GameObject g in colliders)
            {
                g.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
