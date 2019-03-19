using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            string tag = collision.gameObject.tag;
            if (tag.Equals("Girl"))
            {
                RockManager.CanGirlThrow = true;
               // RockManager.CanBoyThrow = false;
            }
            else if (tag.Equals("Boi"))
            {
                //RockManager.CanGirlThrow = false;
                RockManager.CanBoyThrow = true;
            }
        }
    }
}