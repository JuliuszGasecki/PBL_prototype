using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour, IBoxStrategy
{
    private GameObject box;

    public PushBox(GameObject box)
    {
        this.box = box;
        box.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        box.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void useBox()
    {
        Debug.Log("StrategyPush");
    }
}
