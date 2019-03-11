using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbBox : MonoBehaviour, IBoxStrategy
{
    private GameObject box;
    private bool isClimbing = false;
    private GameObject girlGameObject = GameObject.Find("Girl");
    [SerializeField]
    private float climbSpeed = 0.1f;
    private float accuracyOfClimb = 0.03f;
    private float boxPositionY;

    public ClimbBox(GameObject box)
    {
        this.box = box;
        box.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void useBox()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isClimbing = true;
            boxPositionY = (2 * box.transform.position.y) + girlGameObject.transform.lossyScale.y;

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
        float girlPositionY = girlGameObject.transform.position.y;
        float girlPositionX = girlGameObject.transform.position.x;
        float girlPositionZ = girlGameObject.transform.position.z;
        float boxPositionX = box.transform.position.x;
        float boxPositionZ = box.transform.position.z;
        if (girlPositionY < boxPositionY)
        {
            girlGameObject.transform.position = new Vector3(girlPositionX, girlPositionY + this.climbSpeed, girlPositionZ);
        }
        else
        {
            float changedPositionX = girlPositionX;
            float changedPositionZ = girlPositionZ;
            if (checkAccuracyOfX(girlPositionX, boxPositionX))
            {
                changedPositionX = calculateChangedGirlValue(girlPositionX, boxPositionX);
            }
            if (checkAccuracyOfZ(girlPositionZ, boxPositionZ))
            {
                changedPositionZ = calculateChangedGirlValue(girlPositionZ, boxPositionZ);
            }
            transformGirlPositionXZ(changedPositionX, girlPositionY, changedPositionZ);

        }
        if (checkAccuracyOfXZ(girlPositionX, girlPositionZ, boxPositionX, boxPositionZ))
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
        return Mathf.Abs(Mathf.Abs(girlX) - Mathf.Abs(boxX)) > accuracyOfClimb;
    }

    private bool checkAccuracyOfZ(float girlZ, float boxZ)
    {
        return Mathf.Abs(Mathf.Abs(girlZ) - Mathf.Abs(boxZ)) > accuracyOfClimb;
    }

    private bool checkAccuracyOfXZ(float girlX, float girlZ, float boxX, float boxZ)
    {
        return Mathf.Abs(Mathf.Abs(girlX) - Mathf.Abs(boxX)) <= accuracyOfClimb && Mathf.Abs(Mathf.Abs(girlZ) - Mathf.Abs(boxZ)) <= accuracyOfClimb;
    }

    private void endClimbing()
    {
        turnOnGravityForGirl();
        turnOnYBlockForGirl();
        isClimbing = false;
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

}
    
    

