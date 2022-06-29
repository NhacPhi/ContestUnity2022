using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    public Vector2 endPoint;
    private Vector2 startPoint;
    private float lastPointSwitchTime;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        endPoint = transform.position;
       
        lastPointSwitchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        RotateDirection();
    }
    void HandleMovement()
    {
        if(endPoint != startPoint)
        {
            float pathLength = Vector3.Distance(startPoint, endPoint);
            float totalTimeForPath = pathLength / speed;
            float currentTimeOnPath = Time.time - lastPointSwitchTime;
            this.GetComponent<RectTransform>().position = Vector2.Lerp(startPoint, endPoint, currentTimeOnPath / totalTimeForPath);
            if(currentTimeOnPath > totalTimeForPath)
            {
                lastPointSwitchTime = Time.time;
                startPoint = transform.position;
            }
        }
        else
        {
            lastPointSwitchTime = Time.time;
            startPoint = transform.position;
        }
    }
    void RotateDirection()
    {
        if (endPoint != startPoint)
        {
            Vector3 newDirection = (endPoint - startPoint);

            float x = newDirection.x;
            float y = newDirection.y;
            float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;

            transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        }
    }
    public void SetEndpoint(Vector2 pos)
    {
        endPoint = pos;
    }
}
