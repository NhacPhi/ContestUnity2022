using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorWire
{
    BLUE, RED, YELLOW, GREEN
}
public class PowerWireStats : MonoBehaviour
{
    public bool movealbe = false;

    public bool moving = false;
    public Vector3 startPosition;
    public ColorWire objectColor;

    public bool connected = false;

    public Vector3 connectedPostion;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
