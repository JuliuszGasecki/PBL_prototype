using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RockManager : MonoBehaviour
{
    public static bool CanGirlThrow;

    public static bool CanBoyThrow;

    public GameObject Rock;

    public GameObject TrajectoryElement;

    public GameObject Crosshair;
    private int _numberOfTrajectoryElements = 10;

    private Vector3 _start, _end;

    private List<GameObject> _trajectoryElements = new List<GameObject>();

    public float Height;

    private GameObject RockSpawned;
    private float _animation;
    private bool IsClicked = true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _numberOfTrajectoryElements; i++)
            _trajectoryElements.Add(Instantiate(TrajectoryElement) as GameObject);
        SetTrajectoryElementsActivity(false);
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void SetTrajectoryElementsActivity(bool activity)
    {
        foreach(GameObject tre in _trajectoryElements)
        {
            tre.SetActive(activity);
        }
    }

    private void Aim()
    {
        if (Input.GetMouseButton(0))
        {
            if (CanGirlThrow)
            {
                _start = transform.position;
                _end = Crosshair.transform.position;
                if (IsClicked)
                {
                    Crosshair.SetActive(true);
                    SetTrajectoryElementsActivity(true);
                    IsClicked = false;
                }
                DrawTrajectoryArc();
                //ThrowRock();
            }
        }
        else
        {
            if (!IsClicked)
            {
                CanGirlThrow = false;
                Crosshair.SetActive(false);
                SetTrajectoryElementsActivity(false);
                RockSpawned = Instantiate(Rock) as GameObject;
                IsClicked = true;
            }
        }
        ThrowRock();
    }

    private void DrawTrajectoryArc()
    {
        for (float i = 1; i <= _numberOfTrajectoryElements; i++)
        {
            Vector3 currentPisiton = MathParabola.Parabola(_start, _end, Height, i / (float) _numberOfTrajectoryElements);
            _trajectoryElements[(int) i - 1].transform.position = currentPisiton;
            Vector3 nextPosition = MathParabola.Parabola(_start, _end, Height, (i+1) / (float)_numberOfTrajectoryElements);
            float angle = Mathf.Atan2(nextPosition.y - currentPisiton.y, nextPosition.x - nextPosition.x);
            _trajectoryElements[(int)i - 1].transform.eulerAngles = new Vector3(0, (Mathf.Rad2Deg * angle) - 90, 0);
        }
    }

    private void ThrowRock()
    {
        if (RockSpawned!= null)
        {
            _animation += Time.deltaTime * 2.0f;
            _animation = _animation % 5;
            RockSpawned.transform.position = MathParabola.Parabola(_trajectoryElements[0].transform.position, _end, Height, _animation);
            if (RockSpawned.transform.position.y < -1)
                RockSpawned.transform.position = new Vector3(RockSpawned.transform.position.x, 0.0f,
                    RockSpawned.transform.position.z);
        }
        else
        {
            _animation = 0.0f;
        }       
    }
}
