using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    private float time = 10;
    Slider slide;
    
    // Start is called before the first frame update
    void Start()
    {
        slide = GetComponent<Slider>();
        slide.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slide.value += Time.deltaTime*100/time;
        if(slide.value >= 100)
        {
            Debug.Log("EndGame");
        }
    }
}
