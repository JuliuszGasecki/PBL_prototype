using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyRockAfterCollision : MonoBehaviour
{
    public GameObject Point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject pointInstantiate =  Instantiate(Point);
        Vector3 position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        pointInstantiate.transform.position = position;
        Destroy(this.gameObject);
    }
}
