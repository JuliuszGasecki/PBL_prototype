using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformClimbing : MonoBehaviour
{
    public bool isStartPoint = false;
    public bool isReady;

    private void Start()
    {
        isReady = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "plate")
        {
            isReady = false;
        }
        else
        {
            isReady = true;
        }
        if(other.tag == "Boi" && isReady)
        {
            if (Input.GetButtonDown("Fire2") && !isStartPoint)
            {
                Debug.Log("Klikłem q XD");
                isStartPoint = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boi")
        {
            isStartPoint = false;
        }
    }
}
