using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public int ID;
    public bool isDelivered = false;
    public bool isActive = true;

    private void Start()
    {
        addToListOfPackages();
    }

    private void addToListOfPackages()
    {
        PackageManager.PackageManagerInstance.AddToListOfPackages(this);
    }

    public void setID(int ID)
    {
        this.ID = ID;
    }
}
