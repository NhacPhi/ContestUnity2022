using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.KillingNurse
{
    public class ExPosion : MonoBehaviour
    {
        [SerializeField]
        private float speedScale;

        private Animator animator;

        private float maxScale = 0.5f;

        private float currentScale;

        public bool isActive;

        public bool isExploding;

        private CircleCollider2D circleCollider;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            circleCollider = GetComponent<CircleCollider2D>();
            currentScale = 0.2f;
            isActive = true;
            isExploding = false;
        }

        // Update is called once per frame
        void Update()
        {

            if (isActive)
            {
                if (currentScale < maxScale)
                {
                    transform.localScale += new Vector3(1, 1, 1) * speedScale*60*Time.deltaTime;
                    currentScale = transform.localScale.x;
                }
                else
                {
                    animator.SetTrigger("Exploding");
                    circleCollider.enabled = false;
                    isActive = false;
                    isExploding = true;
                    Debug.Log("Exploding");
                    StartCoroutine(WaiteTimeToVisibleObject());
                    //gameObject.SetActive(false);
                }
            }

        }



        private void OnMouseDown()
        {
            gameObject.SetActive(false);
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            currentScale = 0.2f;
        }
        IEnumerator WaiteTimeToVisibleObject()
        {
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            currentScale = 0.2f;
            animator.SetTrigger("Restart");
            //Time.timeScale = 0;
        }
    }
}

