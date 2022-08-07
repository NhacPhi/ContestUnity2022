using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeShape
{
    MEDICAL_COTTON,
    SYRINGE,
    PILL,
    INFUSION_BOTTLE,
    PLASTER,
    THEMOMETR,
    BANDAGE
}
public class Geometry : MonoBehaviour
{
    public TypeShape typeShape;
    private Vector3 startPosition;

    bool moveable;
    bool mouseDown;

    public Vector3 positionCorrectly;
    public bool connected;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        moveable = false;
        mouseDown = false;
        connected = false;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveGeometry();
    }
    void LateUpdate()
    {
        MoveGeometry();
    }
    private void OnMouseExit()
    {
        //moveable = false;
    }

    private void OnMouseUp()
    {
        if(!connected)
        {
            transform.position = startPosition;
            mouseDown = false;
        }
        else
        {
            NurseManager.Instance.number++;
            transform.position = positionCorrectly;
            mouseDown = false;
        }

    }

    private void OnMouseOver()
    {
        moveable = true;
    }

    private void OnMouseDown()
    {
        if (!connected)
        {
            mouseDown = true;
        }
    }
    void MoveGeometry()
    {
        if(NurseManager.Instance.currentState == GameState.INGAME)
        {
            if (mouseDown && moveable)
            {
                float widthMouse = Input.mousePosition.x;
                float heighMouse = Input.mousePosition.y;

                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(widthMouse, heighMouse, 1));
            }
        }

    }

}
