using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    IBoxStrategy strategy;
    private void OnTriggerEnter(Collider other)
    {
        strategy = selectBoxStrategy(other);
    }

    private void OnTriggerStay(Collider other)
    { 
        strategy.useBox();
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private IBoxStrategy selectBoxStrategy(Collider other)
    {
        IBoxStrategy boxStrategy;
        switch (other.tag)
        {
            case "Boi":
                boxStrategy = new PushBox(this.gameObject);
                break;
            case "Girl":
                boxStrategy = new ClimbBox(this.gameObject);
                break;
            default:
                return null;

        }
        return boxStrategy;
    }
}
