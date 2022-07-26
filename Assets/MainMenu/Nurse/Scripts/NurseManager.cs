using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseManager : MonoBehaviour
{
    public static NurseManager Instance { set; get; }


    // Start is called before the first frame update
    private GameObject mainMenu;

    [SerializeField]
    private ProgressBar progressBar;


    public int number;

    private GameState currentState;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentState = GameState.START;

        mainMenu = GameObject.Find("@MainMenuGame");

        number = 0;
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
                    if(number == 5)
                    {
                        currentState = GameState.GAME_OVER;
                    }
                }
                break;
            case GameState.OUT_TIME:
                {
                    //mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
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
