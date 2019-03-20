using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (other.tag == "Boi" )
        {           
            if (Input.GetButtonDown("Fire1"))
            {
                IDestroyable destroyable = gameObject.GetComponent<IDestroyable>();
                if (destroyable != null)
                {
                    destroyable.Destroy();
                }
            }
            
        }
        
    }
}
