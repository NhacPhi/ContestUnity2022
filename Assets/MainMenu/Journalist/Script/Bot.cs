using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public SpriteRenderer redMoon;
    public GameObject turnBack;
    public GameObject lookFor;

    public float[] timers;
    private float currentTime;
    private float milstoneTime;
    private int indexTime = 0;
    float timingRedMoon = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        milstoneTime = timers[indexTime];
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > milstoneTime)
        {
            // LookFor player
            Debug.Log("LookFor");
            if(indexTime < timers.Length-1)
            {
                indexTime++;
                milstoneTime = timers[indexTime];
                StartCoroutine(TimeToLockFor());
            }
            else
            {
                milstoneTime = 100;
            }
        }
    }
    void LookForPlayer()
    {
        turnBack.gameObject.SetActive(false);
        lookFor.gameObject.SetActive(true);
    }
    void TurnBack()
    {
        turnBack.gameObject.SetActive(true);
        lookFor.gameObject.SetActive(false);
    }
    void RedMoonTurnOn(float alpha)
    {
        redMoon.color = new Color(255, 0, 0, alpha);
    }
    void RedMoonTurnOff()
    {
        redMoon.color = new Color(255, 0, 0, 0);
    }
    IEnumerator TimeToLockFor()
    {
        float timeCount = 0;
        float redMoonAlpha = 0;
        while(timeCount < timingRedMoon)
        {
            timeCount += 0.04f;
            redMoonAlpha += 0.05f;
            if (redMoonAlpha > 0.4f)
                redMoonAlpha = 0.4f;
            RedMoonTurnOn(redMoonAlpha);
            yield return new WaitForSeconds(0.04f);
        }
        LookForPlayer();
        yield return new WaitForSeconds(1.5f);
        RedMoonTurnOff();
        TurnBack();
    }
}
