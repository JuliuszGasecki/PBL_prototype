using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlByWSAD : MonoBehaviour, PlayerController
{
    private Rigidbody rigidbody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isBlocked = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isBlocked)
            updateHorizontal();

    }
    public void updateHorizontal()
    {
        float moveHorizontal = Input.GetAxis("Horizontal")/20;
        float moveVertical = Input.GetAxis("Vertical")/20;
        Vector3 newPosition = new Vector3(moveVertical, 0.0f, -moveHorizontal);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);
    }

    public void blockControlls()
    {
        isBlocked = true;
    }

    public void freeControlls()
    {
        isBlocked = false;
    }
}
