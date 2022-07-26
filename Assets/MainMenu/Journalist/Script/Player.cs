using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    CAT,
    HUMAN
}
public class Player : MonoBehaviour
{
    public GameObject cat;
    public GameObject explosion;
    public GameObject ninja;
    public float speed;

    private Animator animatorCat;
    private Animator animatorNinja;
    private Animator animatorExplosion;

    private bool isRun;
    public Type type;
    // Start is called before the first frame update
    void Start()
    {
        animatorCat = cat.gameObject.GetComponent<Animator>();
        animatorNinja = ninja.GetComponent<Animator>();
        animatorExplosion = explosion.GetComponent<Animator>();
        isRun = true;
        animatorNinja.SetBool("isRuning", true);
        type = Type.HUMAN;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(type == Type.HUMAN)
            {
                ninja.gameObject.SetActive(false);
                explosion.gameObject.SetActive(true);
                animatorExplosion.SetTrigger("Explose");
                StartCoroutine(TimingToChange(cat));
                isRun = false;
                animatorNinja.SetBool("isRuning", false);
                type = Type.CAT;
            }
            else
            {
                cat.gameObject.SetActive(false);
                explosion.gameObject.SetActive(true);
                animatorExplosion.SetTrigger("Explose");
                StartCoroutine(TimingToChange(ninja));
                isRun = true;
                type = Type.HUMAN;
            }

        }

        PlayerMovement(); 
    }

    IEnumerator TimingToChange(GameObject ob)
    {
        yield return new WaitForSeconds(0.3f);
        ob.gameObject.SetActive(true);
        if(ob.gameObject.tag == "Ninja")
        {
            animatorNinja.SetBool("isRuning", true);
        }
        
    }
    void PlayerMovement()
    {
        if(isRun)
        {
            // Run forward
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FinishGame")
        {
            JournalistGame.Instance.currentState = GameState.GAME_OVER;
        }
    }
}
