using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cat;
    public GameObject explosion;
    public GameObject ninja;

    private Animator animatorCat;
    private Animator animatorNinja;
    private Animator animatorExplosion;
    // Start is called before the first frame update
    void Start()
    {
        animatorCat = cat.gameObject.GetComponent<Animator>();
        animatorNinja = ninja.GetComponent<Animator>();
        animatorExplosion = explosion.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ninja.gameObject.SetActive(false);
            explosion.gameObject.SetActive(true);
            animatorExplosion.SetTrigger("Explose");
            StartCoroutine(TimingToChange(cat));
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            cat.gameObject.SetActive(false);
            explosion.gameObject.SetActive(true);
            animatorExplosion.SetTrigger("Explose");
            StartCoroutine(TimingToChange(ninja));
        }
    }

    IEnumerator TimingToChange(GameObject ob)
    {
        yield return new WaitForSeconds(0.3f);
        ob.gameObject.SetActive(true);
    }

}
