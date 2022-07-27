using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftCrash : MonoBehaviour
{
    public static AircraftCrash Instance { get; set; }

    public GameState currentState;

    private Level level;

    [SerializeField]
    private ProgressBar progressBar;

    public GameObject mainMenu;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        level = Level.EASY;

        mainMenu = GameObject.Find("@MainMenuGame");

        currentState = GameState.START;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
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
                    mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
                    currentState = GameState.WAITING;
                }
                break;
            case GameState.GAME_OVER:
                {
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
