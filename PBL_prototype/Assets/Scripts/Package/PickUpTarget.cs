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
            if (Input.GetAxisRaw("Fire1") != 0 || Input.GetKeyDown(KeyCode.Alpha9))
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
