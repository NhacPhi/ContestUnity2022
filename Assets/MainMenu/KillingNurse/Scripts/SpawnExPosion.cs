using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MiniGames.KillingNurse
{
    public class SpawnExPosion : MonoBehaviour
    {
        public static SpawnExPosion Instance;

        public List<GameObject> pools;

        public int amountToPool;

        [SerializeField]
        private GameObject prefab;
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
            for (int number = 0; number < amountToPool; number++)
            {
                GameObject ob = Instantiate(prefab,Vector3.zero,Quaternion.identity) as GameObject;
                ob.SetActive(false);
                pools.Add(ob);
            }
        }
        public GameObject GetPooledExposion()
        {
            foreach (var ob in pools)
            {
                if (!ob.activeInHierarchy)
                {
                    return ob;
                }
            }
            return null;
        }
        public bool ExposionCanBePlace(Vector3 pos)
        {
            foreach (var ob in pools)
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
            foreach (var ob in pools)
            {
                if(ob.gameObject.GetComponent<ExPosion>().isExploding && ob.activeInHierarchy)
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
            foreach (var ob in pools)
            {
                ob.gameObject.GetComponent<ExPosion>().isExploding = true;
                ob.gameObject.GetComponent<ExPosion>().isActive = false;
            }
        }
    }
}
