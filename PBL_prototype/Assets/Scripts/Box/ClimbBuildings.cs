using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbBuildings : MonoBehaviour
{
    private GameObject objectToclimbOn;
    private bool isClimbing = false;
    private GameObject girlGameObject = GameObject.Find("Girl");
    [SerializeField]
    private float climbSpeed = 0.06f;
    private float accuracyOfClimb = 0.03f;
    private float pointPositionY;
    private float colliderYPositionChangerValue = 0.3f;
}
