using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveColiiders : MonoBehaviour
{
    [SerializeField]
    private GameObject box;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(box.transform.position.x, this.transform.position.y, box.transform.position.z);
    }
}
