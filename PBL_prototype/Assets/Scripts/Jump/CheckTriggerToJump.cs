using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTriggerToJump : MonoBehaviour
{
    [SerializeField]
    private bool isSpace;

    private void Start()
    {
        isSpace = false;
    }

    private void Update()
    {
        if (Physics.CheckBox(transform.position, transform.lossyScale/4))
        {
            Debug.Log("Nie ma miejsca checkBox");
            isSpace = false;
        }        
        else
        {
            Debug.Log("Jest miejsca checkBox");
            isSpace = true;
        }
    }



    public bool getIsSpace()
    {
        return isSpace;
    }
}
