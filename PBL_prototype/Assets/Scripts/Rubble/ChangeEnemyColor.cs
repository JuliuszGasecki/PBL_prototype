using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyColor : MonoBehaviour
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
            _originalColor = _enemy.GetComponent<Renderer>().material.color;
            _enemy.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("EnemySpecific"))
        {
            _enemy.GetComponent<Renderer>().material.color = _originalColor;
        }
    }
}
