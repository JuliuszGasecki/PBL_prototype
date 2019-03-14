using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageTarget : MonoBehaviour
{
    [SerializeField]
    private int packageID;
    private bool isPackageDelivered = false;
    // Start is called before the first frame update
    void Start()
    {
        packageID = PackageManager.PackageManagerInstance.getLatestID() + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPackageDelivered)
        {
            imGettingOutBois();
        }   
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Boi" || other.tag == "Girl")
        {
            Debug.Log("KolizjaDziała!");
            if (Input.GetAxisRaw("Fire1") != 0 ||Input.GetAxisRaw("Fire2") != 0)
            {
                finishMission();
            }
        }
    }

    private void finishMission()
    {
        if(PackageManager.PackageManagerInstance.checkPackage(packageID) == true)
        {
            isPackageDelivered = true;
            Debug.Log("Skrzynka dostarczona");
        }
    }

    private void imGettingOutBois()
    {
        this.transform.position =
            new Vector3(
                this.transform.position.x,
                this.transform.position.y + 0.5f * Time.deltaTime,
                this.transform.position.z);
    }
}
