using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBuilding : MonoBehaviour
{
    public static ExplodingBuilding Instance { get; set; }

    public int numberWireCorrectly;
    [SerializeField]
    private ProgressBar progressBar;

    public GameObject mainMenu;

    private Level level;

    public GameState currentState;
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

        numberWireCorrectly = 0;
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
                    if(numberWireCorrectly == 4)
                    {
                        currentState = GameState.GAME_OVER;
                    }
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
