﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlByWSAD : MonoBehaviour, PlayerController
{
    private Rigidbody rigidbody;
    [SerializeField]
    private float speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        updateHorizontal();
        jump();

    }
    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Skacze!");
            transform.Translate(0f, 100.0f * Time.deltaTime, 0f);
        }
    }

    public void updateHorizontal()
    {
        float moveHorizontal = Input.GetAxis("Horizontal")/20;
        float moveVertical = Input.GetAxis("Vertical")/20;
        transform.Translate(moveHorizontal* speed, 0f, moveVertical* speed);
    }

}
