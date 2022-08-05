using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    ACTIVE,
    INACTIVE
}

public class Node : MonoBehaviour
{
    [SerializeField]
    private GameObject imageActive;

    [SerializeField]
    private GameObject imageInactive;

    private NodeState currentState;
    private void Awake()
    {
        currentState = NodeState.INACTIVE;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveNode()
    {
        if(currentState == NodeState.INACTIVE)
        {
            imageInactive.gameObject.SetActive(false);
            imageActive.gameObject.SetActive(true);
            currentState = NodeState.ACTIVE;
        }
    }
    public void InactiveNode()
    {
        if (currentState == NodeState.ACTIVE)
        {
            imageInactive.gameObject.SetActive(true);
            imageActive.gameObject.SetActive(false);
            currentState = NodeState.INACTIVE;
        }
    }
}
