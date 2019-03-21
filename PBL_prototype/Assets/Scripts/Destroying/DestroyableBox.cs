using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBox : MonoBehaviour, IDestroyable
{
    public void Destroy()
    {
        MonoBehaviour.Destroy(gameObject);
    }
}
