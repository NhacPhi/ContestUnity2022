using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWireBehavior : MonoBehaviour
{
    bool mouseDown = false;
    public PowerWireStats powerWireS;

    [SerializeField]
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        powerWireS = gameObject.GetComponent<PowerWireStats>();
    }

    private void OnMouseDown()
    {
        if(powerWireS.canMove)
        {
            mouseDown = true;
        }

    }

    private void OnMouseExit()
    {
        if(!powerWireS.moving)
        {
            powerWireS.movealbe = false;
        }
    }

    private void OnMouseUp()
    {
        mouseDown = false;
        if(!powerWireS.connected)
        {
            gameObject.transform.position = powerWireS.startPosition;
        }
        else
        {
            gameObject.transform.position = powerWireS.connectedPostion;
        }

    }

    private void OnMouseOver()
    {
        powerWireS.movealbe = true;
    }

    void MoveWire()
    {
        if(mouseDown && powerWireS.movealbe)
        {
            powerWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 1));
        }
        else
        {
            powerWireS.moving = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        MoveWire();
        line.SetPosition(0, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0));
    }

}
