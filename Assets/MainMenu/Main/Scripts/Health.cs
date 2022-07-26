using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject grayHeart;

    private bool isActive;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }
    public void DeActiveImage()
    {
        grayHeart.SetActive(true);
    }
}
