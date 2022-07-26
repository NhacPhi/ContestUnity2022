using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public float time = 10;
    Slider slide;
    public bool isOutTime;
    // Start is called before the first frame update
    void Start()
    {
        slide = GetComponent<Slider>();
        slide.value = 0;
        isOutTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOutTime)
        {
            slide.value += Time.deltaTime * 100 / time;
            if (slide.value >= 100)
            {
                Debug.Log("EndGame");
                isOutTime = true;
            }
        }
    }
}
