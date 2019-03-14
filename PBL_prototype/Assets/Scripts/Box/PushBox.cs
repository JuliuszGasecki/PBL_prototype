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
        if (Input.GetKeyDown(KeyCode.E))
        {
            box.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        }
        //Debug.Log("StrategyPush");
    }
}
