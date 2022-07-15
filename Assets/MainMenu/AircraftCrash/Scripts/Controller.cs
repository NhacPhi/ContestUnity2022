using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    public float turnSpeedControll;

    [SerializeField]
    public float turnSpeed;

    [SerializeField]
    private GameObject direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateController(turnSpeedControll);
            direction.gameObject.transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateController(-turnSpeedControll);
            direction.gameObject.transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
        }
    }
    void RotateController(float turnSpeed)
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
    }
}
