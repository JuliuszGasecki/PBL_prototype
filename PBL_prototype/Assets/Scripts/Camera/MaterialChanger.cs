using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField]
    private Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = this.GetComponent<Renderer>().material;
    }

    public void UseNewMaterial(Material m)
    {
        this.GetComponent<Renderer>().material = m;
    }

    public void UseOldMaterial()
    {
        Debug.Log("Ustawiam stary materiał");
        this.GetComponent<Renderer>().material = myMaterial;
    }
}
