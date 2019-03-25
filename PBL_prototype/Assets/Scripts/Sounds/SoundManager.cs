using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip alarm;
    [SerializeField]
    private AudioClip battle;
    [SerializeField]
    private AudioClip RPG;

    private float time;
    void Start()
    {
        gameObject.GetComponent<AudioSource>().clip = battle;
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0, 10000) == 14){
            gameObject.GetComponent<AudioSource>().clip = alarm;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Random.Range(0, 1000) == 15){
            gameObject.GetComponent<AudioSource>().clip = battle;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Random.Range(0, 10000) == 156)
        {
            gameObject.GetComponent<AudioSource>().clip = RPG;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
