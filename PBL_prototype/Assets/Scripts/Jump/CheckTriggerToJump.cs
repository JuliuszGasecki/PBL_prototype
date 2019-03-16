using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTriggerToJump : MonoBehaviour
{
    [SerializeField]
    private bool isSpace = true;

    private void Start()
    {
        isSpace = true;
    }
    private void OnTriggerStay(Collider other)
    {
         Debug.Log("A se kolizje wykrywam ;DDDD " + other.name);
         isSpace = false;
    }

    public bool getIsSpace()
    {
        return isSpace;
    }
}
