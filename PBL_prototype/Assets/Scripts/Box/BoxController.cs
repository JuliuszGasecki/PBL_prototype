using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField]
    private IBoxStrategy strategy = new NoStrategy();
    public string selectedStrategy;
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
        if(other.tag == "Girl")
            strategy = new NoStrategy();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        selectedStrategy = "null";
    }

    private IBoxStrategy selectBoxStrategy(Collider other)
    {
        IBoxStrategy boxStrategy;
        switch (other.tag)
        {
            case "Boi":
                boxStrategy = new PushBox(this.gameObject);
                selectedStrategy = "PushBox";
                break;
            case "Girl":
                boxStrategy = new ClimbBox(this.gameObject);
                selectedStrategy = "ClimbBox";
                break;
            default:
                selectedStrategy = "null";
                boxStrategy = new NoStrategy();
                break;

        }
        return boxStrategy;
    }
}
