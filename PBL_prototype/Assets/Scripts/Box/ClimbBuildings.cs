using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbBuildings : MonoBehaviour
{
    private GameObject objectToclimbOn;
    private bool isClimbing = false;
    private GameObject girlGameObject = GameObject.Find("Girl");
    [SerializeField]
    private float climbSpeed = 0.06f;
    private float accuracyOfClimb = 0.03f;
    private float pointPositionY;
    private float colliderYPositionChangerValue = 0.3f;



    private void Climb()
    {
        if (Input.GetButtonDown("Fire1") && !isClimbing)
        {
            objectToclimbOn.GetComponent<BoxCollisionMenager>().DisableCollisions();
            blockControlls();
            lowerGirlColliderPosition();
            isClimbing = true;
            pointPositionY = (2 * objectToclimbOn.transform.position.y) + 0.8f * girlGameObject.transform.lossyScale.y;

        }
        checkClimbingFlagAndClimb();
    }
    private void checkClimbingFlagAndClimb()
    {
        if (isClimbing)
        {
            turnOffYBlockForGirl();
            turnOffGravityForGirl();
            changeGirlPosition();
        }
    }
    private void turnOffYBlockForGirl()
    {
        girlGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }
    private void turnOnYBlockForGirl()
    {
        girlGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }
    private void turnOffGravityForGirl()
    {
        girlGameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    private void turnOnGravityForGirl()
    {
        girlGameObject.GetComponent<Rigidbody>().useGravity = true;
    }
    private void changeGirlPosition()
    {

        Vector3 girlPosition = girlGameObject.transform.position;
        float boxPositionX = objectToclimbOn.transform.position.x;
        float boxPositionZ = objectToclimbOn.transform.position.z;
        if (girlPosition.y < pointPositionY)
        {
            girlGameObject.transform.position = new Vector3(girlPosition.x, girlPosition.y + this.climbSpeed, girlPosition.z);
        }
        else
        {
            float changedPositionX = girlPosition.x;
            float changedPositionZ = girlPosition.z;
            if (checkAccuracyOfX(girlPosition.x, boxPositionX))
            {
                changedPositionX = calculateChangedGirlValue(girlPosition.x, boxPositionX);
            }
            if (checkAccuracyOfZ(girlPosition.z, boxPositionZ))
            {
                changedPositionZ = calculateChangedGirlValue(girlPosition.z, boxPositionZ);
            }
            transformGirlPositionXZ(changedPositionX, girlPosition.y, changedPositionZ);

        }
        if (checkAccuracyOfXZ(girlPosition.x, girlPosition.z, boxPositionX, boxPositionZ))
        {
            endClimbing();
        }
    }

    public float calculateChangedGirlValue(float girlValue, float boxValue)
    {
        return girlValue + checkBoxVariable(boxValue, girlValue) * climbSpeed / 2;
    }

    public void transformGirlPositionXZ(float girlX, float girlY, float girlZ)
    {
        girlGameObject.transform.position = new Vector3(girlX, girlY, girlZ);
    }

    private bool checkAccuracyOfX(float girlX, float boxX)
    {
        return Mathf.Abs(girlX - boxX) >= accuracyOfClimb;
    }

    private bool checkAccuracyOfZ(float girlZ, float boxZ)
    {
        return Mathf.Abs(girlZ - boxZ) >= accuracyOfClimb;
    }

    private bool checkAccuracyOfXZ(float girlX, float girlZ, float boxX, float boxZ)
    {
        return Mathf.Abs(girlX - boxX) <= accuracyOfClimb && Mathf.Abs(girlZ - boxZ) <= accuracyOfClimb;
    }

    private void endClimbing()
    {
        turnOnGravityForGirl();
        turnOnYBlockForGirl();
        isClimbing = false;
        increaseGirlColliderPosition();
        objectToclimbOn.GetComponent<BoxCollisionMenager>().SetCollision();
        freeControlls();
    }

    private int checkBoxVariable(float boxValue, float pointValue)
    {
        if (boxValue - pointValue >= 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    private void lowerGirlColliderPosition()
    {
        this.girlGameObject.GetComponent<BoxCollider>().center =
            new Vector3(this.girlGameObject.GetComponent<BoxCollider>().center.x,
            this.girlGameObject.GetComponent<BoxCollider>().center.y - this.colliderYPositionChangerValue,
            this.girlGameObject.GetComponent<BoxCollider>().center.z);
    }

    private void increaseGirlColliderPosition()
    {
        this.girlGameObject.GetComponent<BoxCollider>().center =
            new Vector3(this.girlGameObject.GetComponent<BoxCollider>().center.x,
            this.girlGameObject.GetComponent<BoxCollider>().center.y + this.colliderYPositionChangerValue,
            this.girlGameObject.GetComponent<BoxCollider>().center.z);
    }

    private void blockControlls()
    {
        this.girlGameObject.GetComponent<ControlByWSAD>().blockControlls();
    }

    private void freeControlls()
    {
        this.girlGameObject.GetComponent<ControlByWSAD>().freeControlls();
    }

}
