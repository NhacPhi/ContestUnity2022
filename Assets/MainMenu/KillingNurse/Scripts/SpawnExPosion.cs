using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExPosion : MonoBehaviour
{
    public static SpawnExPosion Instance;
    public List<GameObject> listElementExposion;
    public List<GameObject> listExpostions;
    public int amountToPool;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnExposionPooling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnExposionPooling()
    {
        GameObject tmp;
        for (int number = 0; number < amountToPool; number++)
        {
            foreach (var ob in listElementExposion)
            {
                tmp = Instantiate(ob);
                tmp.SetActive(false);
                listExpostions.Add(tmp);
            }
        }
    }
    public GameObject GetPooledExposion()
    {
        foreach(var ob in listExpostions)
        {
            if(!ob.activeInHierarchy)
            {
                return ob;
            }
        }
        return null;
    }
}
