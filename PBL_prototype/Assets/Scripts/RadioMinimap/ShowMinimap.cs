using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMinimap : MonoBehaviour
{
    public GameObject Map;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetMapActivity();
    }

    void SetMapActivity()
    {

        if (Input.GetButtonDown("Map1") && Input.GetButtonDown("Map2"))
        {
            Map.SetActive(true);
        }

        if (Input.GetButtonUp("Map1") && Input.GetButtonUp("Map2"))
        {
            Map.SetActive(false);
        }
    }

}