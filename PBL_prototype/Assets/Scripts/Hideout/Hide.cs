using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private bool isHidden = false;
    [SerializeField]
    private GameObject model;
    

    public void HideObject()
    {
        isHidden = true;
        gameObject.GetComponent<PlayerController>().blockControlls();
        Debug.Log(gameObject.name + " jest ukryty");
        model.GetComponent<HideMaterialChanger>().ChangeMaterialOnHide();
    }

    public void UnhideObject()
    {
        isHidden = false;
        gameObject.GetComponent<PlayerController>().freeControlls();
        Debug.Log(gameObject.name + " już NIE jest ukryty");
        model.GetComponent<HideMaterialChanger>().ChangeMaterialOnUnhide();
    }

    public bool IsObjectHidden()
    {
        return isHidden;
    }
   
}
