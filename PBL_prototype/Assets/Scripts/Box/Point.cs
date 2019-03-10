using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    private void Start()
    {
        setPoint();
    }

    private void Update()
    {
        setPoint();
    }
    
    private void setPoint()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }

}
