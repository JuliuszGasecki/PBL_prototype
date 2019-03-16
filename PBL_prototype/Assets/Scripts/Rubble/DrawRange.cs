using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRange : MonoBehaviour
{
    public Vector3 MaxScale;
    public float StartScaleX;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetScale();
    }

    private void SetScale()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, MaxScale, Speed * Time.deltaTime);
        if (transform.localScale.x >= 7.4f)
            transform.localScale = new Vector3(StartScaleX, StartScaleX, 1.0f);
    }
}