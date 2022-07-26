using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    public GameState currentState;

    public Level level;

    public float score;

    [SerializeField]
    GameObject mainMenu;

    [SerializeField]
    GameObject healthManger;

    private void Awake()
    {
        Instance = this;
        level = Level.EASY;
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.START;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case GameState.START:
                {

                }
                break;
            case GameState.INGAME:
                {

                }
                break;
            case GameState.GAME_OVER:
                {
                    
                }
                break;
            case GameState.WAITING:
                {
                    Destroy(mainMenu);
                    Destroy(healthManger);
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
