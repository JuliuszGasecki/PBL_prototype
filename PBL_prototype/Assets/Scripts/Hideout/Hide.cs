using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private bool isHidden = false;

    public void HideObject()
    {
        isHidden = true;
        gameObject.GetComponent<PlayerController>().blockControlls();
        //SetAlphaToMaterial(0.5f);
        Debug.Log(gameObject.name + " jest ukryty");
    }

    public void UnhideObject()
    {
        isHidden = false;
        gameObject.GetComponent<PlayerController>().freeControlls();
        //SetAlphaToMaterial(1.0f);
        Debug.Log(gameObject.name + " już NIE jest ukryty");
    }

    public bool IsObjectHidden()
    {
        return isHidden;
    }

    private void SetAlphaToMaterial(float alpha)
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = alpha;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
