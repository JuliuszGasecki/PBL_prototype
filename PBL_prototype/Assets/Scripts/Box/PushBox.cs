using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour, IBoxStrategy
{
    private GameObject box;

    public PushBox(GameObject box)
    {
        this.box = box;
    }

    public void useBox()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            box.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        }
        //Debug.Log("StrategyPush");
    }
}
