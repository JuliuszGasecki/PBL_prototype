using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemies : MonoBehaviour
{
    private bool _isHacked;
    private GameObject[]_enemiesIcons;
    // Start is called before the first frame update
    void Start()
    {
        _enemiesIcons = GameObject.FindGameObjectsWithTag("EnemyIcon");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider collision)
    {
        string tag = collision.gameObject.tag;
        if (Input.GetKeyDown(KeyCode.E) && tag.Equals("Girl") && !_isHacked)
        {
            _isHacked = true;
        }

        if (_isHacked && tag.Equals("Girl"))
        {
            foreach (GameObject i in _enemiesIcons)
            {
                i.layer = LayerMask.NameToLayer("Minimap");
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Girl"))
        {
            foreach (GameObject i in _enemiesIcons)
            {
                i.layer = LayerMask.NameToLayer("Hiden");
            }
        }
    }
}
