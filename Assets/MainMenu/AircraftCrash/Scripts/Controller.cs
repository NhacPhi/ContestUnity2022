using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
   ROTATE_LEFT = 0,
   ROTATE_RIGHT,
   WAIT
}
public class Controller : MonoBehaviour
{
    [SerializeField]
    public float turnSpeedControll;

    [SerializeField]
    public float turnSpeed;

    [SerializeField]
    private GameObject direction;

    public State currentState;

    private float timingRotate = 0;

    private float waittime = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.ROTATE_LEFT;
    }

    // Update is called once per frame
    void Update()
    {
        if(AircraftCrash.Instance.currentState == GameState.INGAME)
        {
            if (AircraftCrash.Instance.currentState == GameState.INGAME)
            {
                switch (currentState)
                {
                    case State.WAIT:
                        {
                            timingRotate = 0;
                            waittime += Time.deltaTime;
                            if (waittime > 0.1)
                            {
                                int index = Random.Range(0, 10);
                                if (index > 4)
                                {
                                    currentState = State.ROTATE_RIGHT;
                                }
                                else
                                {
                                    currentState = State.ROTATE_LEFT;
                                }
                            }
                        }
                        break;
                    case State.ROTATE_LEFT:
                        {
                            waittime = 0;
                            timingRotate += Time.deltaTime;
                            if (timingRotate < 3)
                            {
                                RotateController(turnSpeedControll / 2);
                                direction.gameObject.transform.Rotate(Vector3.forward, turnSpeed / 2 * Time.deltaTime);
                            }
                            else
                            {
                                currentState = State.WAIT;
                            }

                        }
                        break;
                    case State.ROTATE_RIGHT:
                        {
                            waittime = 0;
                            timingRotate += Time.deltaTime;
                            if (timingRotate < 3)
                            {
                                RotateController(-turnSpeedControll / 2);
                                direction.gameObject.transform.Rotate(Vector3.forward, -turnSpeed / 2 * Time.deltaTime);
                            }
                            else
                            {
                                currentState = State.WAIT;
                            }

                        }
                        break;
                }
            }


            if (Input.GetKey(KeyCode.A))
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
    }
    void RotateController(float turnSpeed)
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
    }
}
