using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformCrawling : MonoBehaviour
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
        if(other.tag == "Girl" && isReady)
        {
            if (Input.GetButtonDown("Fire1") && !isStartPoint)
            {
                Debug.Log("Klikłem e XD");
                isStartPoint = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Girl")
        {
            isStartPoint = false;
        }
    }
}
