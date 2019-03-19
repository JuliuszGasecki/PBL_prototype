using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformCrawling : MonoBehaviour
{
    public bool isStartPoint = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Girl")
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
