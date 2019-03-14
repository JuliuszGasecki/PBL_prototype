using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    private static PackageManager _instance = null;
    [SerializeField]
    private List<Package> packages = new List<Package>();
    public GameObject myPrefab;


    public static PackageManager PackageManagerInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PackageManager>();
            }
            return _instance;
        }
    }

    public int getLatestID()
    {
        return packages.Count - 1;
    }

    public void AddToListOfPackages(Package package)
    {
        packages.Add(package);
        packages[packages.Count - 1].setID(packages.Count - 1);
    }

    public bool checkPackage(int ID)
    {
        Debug.Log("Dostałem " + ID);
        if (packages[ID].isActive)
        {
            packages[ID].isActive = false;
            packages[ID].isDelivered = true;
            return true;
        }
        else return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(myPrefab, )
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
