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

        private float maxScale = 8;

        private float currentScale;

        public bool isActive;

        private CircleCollider2D circleCollider;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            circleCollider = GetComponent<CircleCollider2D>();
            currentScale = 1;
            isActive = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (isActive)
            {
                if (currentScale < maxScale)
                {
                    transform.localScale += new Vector3(1, 1, 1) * speedScale;
                    currentScale = transform.localScale.x;
                }
                else
                {
                    animator.SetTrigger("Exposion");
                    circleCollider.enabled = false;
                    isActive = false;
                    StartCoroutine(WaiteTimeToVisibleObject());
                    //gameObject.SetActive(false);
                }
            }

        }

        //private void OnDisable()
        //{
        //    isActive = false;
        //}

        //private void OnEnable()
        //{
        //    isActive = true;
        //}


        private void OnMouseDown()
        {
            gameObject.SetActive(false);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            currentScale = 1;
        }
        IEnumerator WaiteTimeToVisibleObject()
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            currentScale = 1;
        }
    }
}

