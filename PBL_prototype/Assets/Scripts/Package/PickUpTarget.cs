using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTarget : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Girl" || other.tag == "Boi")
        {
            Debug.Log("Podnoszem skrzynkę");
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Alpha9))
            {
                Destroy(gameObject);
            }
        }
    }
}
