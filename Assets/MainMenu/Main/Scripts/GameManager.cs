using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private AudioManager audioManager;

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
                    currentState = GameState.INGAME;
                }
                break;
            case GameState.GAME_OVER:
                {
                    if (isWin)
                    {
                        currentState = GameState.CUT_SCENE;
                    }
                    else
                    {
                        currentState = GameState.WAITING;
                    }
                    //currentState = GameState.WAITING;
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
                    Debug.Log("Destroy Object");
                    Destroy(mainMenu);
                    Destroy(healthManger);
                    Destroy(audioManager.gameObject);
                    Destroy(popup.gameObject);
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
