using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    [SerializeField]
    private List<Health> healths;

    public int currentHeart;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHeart = 2;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHeart == -1)
        {
            if (GameManager.Instance.currentState != GameState.GAME_OVER)
            {
                GameManager.Instance.currentState = GameState.GAME_OVER;
            }
        }
    }
    public void DescreaseHeart()
    {
        healths[currentHeart].GetComponent<Health>().DeActiveImage();
        currentHeart--;
    }
}
