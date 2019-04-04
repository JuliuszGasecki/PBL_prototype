using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeTutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject frontImage;
    [SerializeField]
    private Sprite keys;
    private float timer;

    private void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 5)
        {
            frontImage.GetComponent<Image>().sprite = keys;
        }
        if(Time.time - timer > 12)
        {
            Destroy(frontImage);
            Destroy(gameObject);
        }
    }
}
