using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemies : MonoBehaviour
{
    private bool _isHacked;
    private GameObject[]_enemiesIcons;
    private GameObject[] _enemiesLastPositionIcons;

    public GameObject LastPositionIcon;
    // Start is called before the first frame update
    void Start()
    {
        _enemiesIcons = GameObject.FindGameObjectsWithTag("EnemyIcon");
        CreateLPIcons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetLayer(string layer, GameObject[] list)
    {
        foreach (GameObject i in list)
        {
            i.layer = LayerMask.NameToLayer(layer);
        }
    }

    private void CreateLPIcons()
    {
        for (int i = 0; i < _enemiesIcons.Length; i++)
        {
            GameObject lp = Instantiate(LastPositionIcon) as GameObject;
        }
        _enemiesLastPositionIcons = GameObject.FindGameObjectsWithTag("EnemyLPIcon");
    }

    private void SetLPPositon()
    {
        int i = 0;
        foreach (GameObject g in _enemiesLastPositionIcons)
        {
            Vector3 position = new Vector3(_enemiesIcons[i].transform.position.x, 1.0f,
                _enemiesIcons[i].transform.position.z);
            g.transform.position = position;
            i++;
        }
    }

    void OnTriggerStay(Collider collision)
    {
        string tag = collision.gameObject.tag;
        if (Input.GetKeyDown(KeyCode.E) && tag.Equals("Girl") && !_isHacked)
        {
            _isHacked = true;
            SetLayer("Hiden", _enemiesLastPositionIcons);
            SetLPPositon();
        }

        if (_isHacked && tag.Equals("Girl"))
        {
            SetLayer("Minimap", _enemiesIcons);
            SetLayer("Hiden", _enemiesLastPositionIcons);
            SetLPPositon();
        }
    }

    void OnTriggerExit(Collider collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Girl"))
        {
            SetLayer("Hiden", _enemiesIcons);
            SetLayer("Minimap", _enemiesLastPositionIcons);
        }
    }
}
