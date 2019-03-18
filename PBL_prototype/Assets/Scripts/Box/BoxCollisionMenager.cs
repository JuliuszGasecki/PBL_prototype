using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisionMenager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> colliders;

    public void SetCollision()
    {
        foreach (GameObject g in colliders)
        {
            g.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void DisableCollisions()
    {
        foreach (GameObject g in colliders)
        {
            g.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
   
