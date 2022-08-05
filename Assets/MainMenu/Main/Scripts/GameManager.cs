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

    [SerializeField]
    private PopupEndFGame popup;

    public bool isWin;
    private void Awake()
    {
        Instance = this;
        level = Level.EASY;
        DontDestroyOnLoad(this.gameObject);
        isWin = false;
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
                    currentState = GameState.INGAME;
                }
                break;
            case GameState.INGAME:
                {
                    //currentState = GameState.INGAME;
                }
                break;
            case GameState.GAME_OVER:
                {
                    if(isWin)
                    {
                        currentState = GameState.CUT_SCENE;
                    }
                    else
                    {
                        currentState = GameState.WAITING;
                    }
                }
                break;
            case GameState.CUT_SCENE:
                {
                    popup.ShopPopupWinGame();
                    currentState = GameState.INGAME;
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
