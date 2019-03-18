using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMaterialChanger : MonoBehaviour
{
    private Color originalColor;
    private Color hiddenColor;

    private void Start()
    {
        originalColor = gameObject.GetComponent<MeshRenderer>().material.color;
        // hiddenColor = originalColor;
        // hiddenColor.a = 0.0f;
        hiddenColor = Color.black;
        hiddenColor.a = 0.5f;
    }


    public void ChangeMaterialOnHide()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = hiddenColor;
    }

    public void ChangeMaterialOnUnhide()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = originalColor;
    }
}
