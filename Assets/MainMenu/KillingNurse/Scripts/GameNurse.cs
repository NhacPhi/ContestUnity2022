using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.KillingNurse
{
    public class GameNurse : MonoBehaviour
    {
        private float width = 7.5f;
        private float height = 4f;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(WaitTimeToSpawnExposion());
        }

        // Update is called once per frame
        void Update()
        {

        }
        IEnumerator WaitTimeToSpawnExposion()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                GameObject ob = SpawnExPosion.Instance.GetPooledExposion();
                do
                {
                    float widthOb = Random.Range(-width, width);
                    float heightOb = Random.Range(-height, height);
                    ob.transform.position = new Vector3(widthOb, heightOb);
                } while (!SpawnExPosion.Instance.ExposionCanBePlace(ob.transform.position));

                ob.gameObject.SetActive(true);
                ob.gameObject.GetComponent<ExPosion>().isActive = true;
                ob.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            }

        }
    }

}
