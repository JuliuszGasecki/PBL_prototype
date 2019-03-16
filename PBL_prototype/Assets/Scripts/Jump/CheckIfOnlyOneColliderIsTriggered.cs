using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfOnlyOneColliderIsTriggered : MonoBehaviour
{
    [SerializeField]
    private int amountOfTriggers = 0;

    public void addTrigger()
    {
        amountOfTriggers++;
    }

    public void subtractTrigger()
    {
        amountOfTriggers--;
    }

    public int getAmountOfTriggers()
    {
        return amountOfTriggers;
    }

}
