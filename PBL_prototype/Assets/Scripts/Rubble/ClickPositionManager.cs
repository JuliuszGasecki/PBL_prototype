using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager : MonoBehaviour
{
    public LayerMask LayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangePositionDependsOnMouse();
    }

    private void ChangePositionDependsOnMouse()
    {
        Vector3 clickPosition = -Vector3.one;
       // clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0, 5f));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask))
        {
            clickPosition = hit.point;
        }

        transform.position = clickPosition;
    }
}
