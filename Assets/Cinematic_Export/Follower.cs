using PathCreation;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public static bool showCinematic = true;

    public static bool Following { get; set; } = false;

    private PathCreator path;
    [SerializeField] private float speed = 7.0f;
    [SerializeField] private bool reversedPath = false;
    [SerializeField] private bool reversedCamera = false;

    private float t = 0;


    private void Awake()
    {
        if (!showCinematic)
        {
            Following = false;
            Destroy(transform.parent.gameObject);
            return;
        }
        showCinematic = false;

        Following = true;
        path = transform.parent.GetComponentInChildren<PathCreator>();

        if (reversedPath)
        {
            t = path.path.length;
        }
    }

    private void Update()
    {
        if ((!reversedPath && t >= path.path.length) || (reversedPath && t <= 0))
        {
            Following = false;
            Destroy(transform.parent.gameObject);
        }

        if (reversedPath)
        {
            t -= GetSpeed() * Time.deltaTime;
        }
        else
        {
            t += GetSpeed() * Time.deltaTime;
        }

        transform.position = path.path.GetPointAtDistance(t, EndOfPathInstruction.Stop);
        Vector3 v = path.path.GetRotationAtDistance(t, EndOfPathInstruction.Stop).eulerAngles;

        if (!reversedCamera)
        {
            transform.rotation = Quaternion.Euler(0, v.y, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, v.y + 180, 0);
        }
    }


    float startStopDist = 10.0f;
    private float GetSpeed()
    {
        if (t < startStopDist)
        {
            return Mathf.Abs(Mathf.Pow(t / startStopDist, 3)) * (speed - 1) + 1;
        }
        else if (t >= path.path.length - startStopDist)
        {
            return Mathf.Abs(Mathf.Pow((path.path.length - t) / startStopDist, 3)) * (speed - 1) + 1;
        }
        else
        {
            return speed;
        }
    }
}
