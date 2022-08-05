using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class Heart : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer video;

    [SerializeField]
    private GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveHeart()
    {
        video.gameObject.SetActive(true);
        video.Play();
        image.SetActive(true);
    }
    public void DeactiveHeart()
    {
        video.gameObject.SetActive(false);
        //video.Play();
        image.SetActive(false);
    }
}
