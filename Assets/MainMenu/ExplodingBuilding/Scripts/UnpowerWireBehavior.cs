using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpowerWireBehavior : MonoBehaviour
{
    UnPowerWireStats unpowerWireS;
    // Start is called before the first frame update
    void Start()
    {
        unpowerWireS = GetComponent<UnPowerWireStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PowerWireStats>())
        {
            PowerWireStats powerWireS = collision.GetComponent<PowerWireStats>();
            powerWireS.connected = true;
            powerWireS.connectedPostion = new Vector3(transform.position.x,transform.position.y,-1);
            unpowerWireS.connected = true;
            if(powerWireS.objectColor == unpowerWireS.objectColor)
            {
                powerWireS.canMove = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerWireStats>())
        {
            PowerWireStats powerWireS = collision.GetComponent<PowerWireStats>();
            powerWireS.connected = false;
            unpowerWireS.connected = false;
            powerWireS.canMove = true;
        }
    }

    void ManageLight()
    {
        if (unpowerWireS.connected)
        {
            // Handle turn on the light
        }
        else
        {
            // Handle turn off the light
        }
    }
}
