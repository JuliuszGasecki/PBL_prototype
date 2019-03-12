using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowPath : MonoBehaviour
{
    [SerializeField]
    protected float maxNodeDistance;
    [SerializeField]
    protected float maxAngleDifference;
    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    protected float rotationSpeed;

    public void Move(Vector3 movementDirection)
    {
        float angle = Vector3.SignedAngle(transform.forward, movementDirection, Vector3.up);
        if (angle > maxAngleDifference || angle < -1 * maxAngleDifference)
        {
            if (Vector3.SignedAngle(transform.forward, movementDirection, Vector3.up) > maxAngleDifference)
            {
                transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(transform.up, -1 * rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }
}
