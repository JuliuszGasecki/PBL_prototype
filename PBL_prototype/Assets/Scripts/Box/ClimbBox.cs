using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbBox : MonoBehaviour, IBoxStrategy
{
    private GameObject box;

    public ClimbBox(GameObject box)
    {
        this.box = box;
        box.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void useBox()
    {
        Debug.Log("ClimbBox");
    }
}
