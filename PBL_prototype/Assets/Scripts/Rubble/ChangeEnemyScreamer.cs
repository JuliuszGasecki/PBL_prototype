using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyScreamer : MonoBehaviour
{
    private GameObject _enemy;
    private Color _originalColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("EnemySpecific"))
        {
            _enemy = collision.gameObject;
            _enemy.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("EnemySpecific"))
        {
            _enemy.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
