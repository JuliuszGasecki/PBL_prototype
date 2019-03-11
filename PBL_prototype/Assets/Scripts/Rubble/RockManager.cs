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

    public float h;

    private GameObject RockSpawned;

    private bool IsClicked;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _numberOfTrajectoryElements; i++)
            _trajectoryElements.Add(Instantiate(TrajectoryElement) as GameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        if (Input.GetMouseButton(0))
        {
            IsClicked = true;
            if (CanGirlThrow)
            {
                _start = transform.position;
                Crosshair.SetActive(true);
                _end = Crosshair.transform.position;
                DrawTrajectoryArc();
                //ThrowRock();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_start, _end);
        float count = 20.0f;
        Vector3 lastPosition = _start;
        for (int i = 0; i < count + 1; i++)
        {
            Vector3 position = MathParabola.Parabola(_start, _end, h, (i / count));
            Gizmos.color = Color.red;
            Gizmos.DrawLine(lastPosition, position);
            lastPosition = position;
        }
    }

    private void DrawTrajectoryArc()
    {
        float time = 0.0f;
        for (float i = 1; i <= _numberOfTrajectoryElements; i++)
        {
            time++;
            Vector3 currentPisiton = MathParabola.Parabola(_start, _end, h, i / (float) _numberOfTrajectoryElements);
            _trajectoryElements[(int) i - 1].transform.position = currentPisiton;
            Vector3 nextPosition = MathParabola.Parabola(_start, _end, h, (i+1) / (float)_numberOfTrajectoryElements);
            float angle = Mathf.Atan2(nextPosition.y - currentPisiton.y, nextPosition.x - nextPosition.x);
            _trajectoryElements[(int)i - 1].transform.eulerAngles = new Vector3(0, (Mathf.Rad2Deg * angle) - 90, 0);
        }
    }

    private void ThrowRock()
    {
        RockSpawned = Instantiate(Rock) as GameObject;
        RockSpawned.transform.position = MathParabola.Parabola(_start, _end, h, Time.time % 1);
    }
}
