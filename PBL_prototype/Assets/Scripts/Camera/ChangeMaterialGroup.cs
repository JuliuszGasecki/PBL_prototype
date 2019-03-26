using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialGroup : MonoBehaviour
{
    public void UseNewMaterial(Material mat)
    {
        foreach(MaterialChanger mc in gameObject.GetComponentsInChildren<MaterialChanger>())
        {
            mc.UseNewMaterial(mat);
        }
    }

    public void UseOldMaterial()
    {
        foreach (MaterialChanger mc in gameObject.GetComponentsInChildren<MaterialChanger>())
        {
            mc.UseOldMaterial();
        }
    }
}
