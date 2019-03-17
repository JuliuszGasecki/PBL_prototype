using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Awake()
    {
        DestroyObjectDelayed();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("EnemySpecific"))
        {
            var Enemy = collision.gameObject.GetComponent<FollowSpecificPath>();
            Enemy.IsTrigger = true;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Enemy.RockPosition = transform.position;
            Destroy(this.gameObject);
        }
    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 2.0f);
    }
}
