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
    [SerializeField]
    private GameObject girl;
    private float time;
    private Vector3 lastPosition;

    private void Start()
    {
        girl = GameObject.Find("Girl");
        time = 0;
        //colliderToCheckSpace = Resources.Load<GameObject>("JumpChecker");
    }

    private void Update()
    {
        if(checker != null && lastPosition != transform.position)
        {
            Destroy(checker);
        }
        if (Time.time - time > 0.5 && time != 0)
        {
            girl.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            girl.GetComponent<ControlByWSAD>().freeControlls();
            time = 0;
        }
        lastPosition = this.transform.position;
    }

    public void Jump()
    {
        Debug.Log("Free Sex");
        girl.GetComponent<ControlByWSAD>().blockControlls();
        box.GetComponent<BoxCollisionMenager>().DisableCollisions();
        Vector3 calculatedVector = calculateVectorBetweenBoxAndCollider();
        girl.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        girl.transform.position = calculatedVector;
        box.GetComponent<CheckIfOnlyOneColliderIsTriggered>().setZeroTriggers();
        time = Time.time;
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
                        Debug.Log("Skaczę! gotowa do skoku");
                        
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
