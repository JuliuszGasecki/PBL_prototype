using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFromBox : MonoBehaviour, IJump
{
    [SerializeField]
    private GameObject box;
    [SerializeField]
    private GameObject colliderToCheckSpace;
    [SerializeField]
    private bool isSpaceToJump = false;
    [SerializeField]
    private bool isTriggered = false;
    [SerializeField]
    private GameObject checker;
    private int destroyIterator;

    private void Start()
    {
        destroyIterator = 0;
        //colliderToCheckSpace = Resources.Load<GameObject>("JumpChecker");
    }

    private void Update()
    {
        if(checker != null && destroyIterator==60)
        {
            Destroy(checker);
        }
        destroyIterator++;
        if(destroyIterator > 60)
        {
            destroyIterator = 0;
        }
    }

    public void Jump()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Girl" || other.tag =="Boi")
        {
            box.GetComponent<CheckIfOnlyOneColliderIsTriggered>().addTrigger();
            isTriggered = true;
        }
           
    }

    private bool checkIfOnlyOneCollisionIsTriggered()
    {
        if(box.GetComponent<CheckIfOnlyOneColliderIsTriggered>().getAmountOfTriggers() != 1)
        {
            return false;
        }
        return true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Girl" || other.tag == "Boi")
        {
            isSpaceToJump = checkJump();
            if (box.GetComponent<CheckIfOnlyOneColliderIsTriggered>().getAmountOfTriggers() == 1)
            {
                if (isSpaceToJump)
                {
                    Debug.Log("jestem gotowa do skoku");
                    if(Input.GetAxisRaw("Fire1")!=0 || Input.GetAxisRaw("Fire2") != 0)
                    {
                        Jump();
                    }
                }
                else
                {
                    Debug.Log("Nie ma miejsca");
                }
                
            }
            else
            {
                Debug.Log("za dużo kolizji");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Girl" || other.tag == "Boi")
        {
            box.GetComponent<CheckIfOnlyOneColliderIsTriggered>().subtractTrigger();
            isTriggered = false;
            isSpaceToJump = false;
        }
    }

    private bool checkJump()
    {
        if(checker == null)
            this.checker = Instantiate(colliderToCheckSpace, calculateVectorBetweenBoxAndCollider(), box.transform.rotation) as GameObject;
        if (checker.GetComponent<CheckTriggerToJump>().getIsSpace())
        {
            return true;
        }
        else
        {
            return false;
        }
        
        
    }

    private Vector3 calculateVectorBetweenBoxAndCollider()
    {
        Vector3 calculatedVector = new Vector3(2*(transform.position.x - box.transform.position.x) + transform.parent.position.x, 1.1f, 2 * ( transform.position.z - box.transform.position.z) + transform.parent.position.z);
        return calculatedVector;
    }



    public bool getInformationAboutFreeSpace(bool info)
    {
        return info;
    }

}
