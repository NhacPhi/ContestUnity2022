using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalistGame : MonoBehaviour
{
    public static JournalistGame Instance { set; get; }
    public GameObject mainMenu;

    [SerializeField]
    private ProgressBar progressBar;

    [SerializeField]
    public Bot bot;

    [SerializeField]
    public Player player;

    public GameState currentState;

    private Level level;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.START;
        mainMenu = GameObject.Find("@MainMenuGame");
        level = Level.EASY;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case GameState.START:
                {
                    currentState = GameState.INGAME;
                }
                break;
            case GameState.INGAME:
                {
                    if (progressBar.isOutTime)
                    {
                        currentState = GameState.OUT_TIME;
                    }
                }
                break;
            case GameState.OUT_TIME:
                {
                    mainMenu.GetComponent<MainMenuManager>().DecreaseHealth();
                    currentState = GameState.GAME_OVER;
                }
                break;
            case GameState.GAME_OVER:
                {
                    Debug.Log("Game Over");
                    mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
                    currentState = GameState.WAITING;
                }
                break;
            case GameState.WAITING:
                {

                }
                break;
        }

    }
}
