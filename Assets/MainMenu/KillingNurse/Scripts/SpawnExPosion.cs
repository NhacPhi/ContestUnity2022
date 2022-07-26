using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MiniGames.KillingNurse
{
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
            foreach (var ob in listExpostions)
            {
                if (!ob.activeInHierarchy && !ob.gameObject.GetComponent<ExPosion>().isExploding)
                {
                    return ob;
                }
            }
            return null;
        }
        public bool ExposionCanBePlace(Vector3 pos)
        {
            foreach (var ob in listExpostions)
            {
                if (ob.activeInHierarchy)
                {
                    if (Mathf.Abs(Vector3.Distance(pos, ob.gameObject.transform.position)) < 1.8f)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
        public bool CheckGameOver()
        {
            bool isGameOver = false;
            foreach (var ob in listExpostions)
            {
                if (ob.gameObject.GetComponent<ExPosion>().isExploding)
                {
                    isGameOver = true;
                    return isGameOver;
                }
            }
            return isGameOver;
        }
        public void PauseExposion()
        {
            Debug.Log("Pause");
            foreach (var ob in listExpostions)
            {
                ob.gameObject.GetComponent<ExPosion>().isExploding = true;
                ob.gameObject.GetComponent<ExPosion>().isActive = false;
            }
        }
    }
}
