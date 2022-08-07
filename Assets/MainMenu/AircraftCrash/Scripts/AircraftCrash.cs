using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AircraftCrash : MonoBehaviour
{
    public static AircraftCrash Instance { get; set; }

    public GameState currentState;

    private Level level;

    [SerializeField]
    private ProgressBar progressBar;

    public GameObject mainMenu;

    [SerializeField]
    private VideoPlayer cutScene;

    [SerializeField]
    private GameObject bgEndGame;

    bool isWin;

    [SerializeField]
    private GameObject tutorialGame;

    [SerializeField]
    private Canvas UI;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        level = Level.EASY;

        mainMenu = GameObject.Find("@MainMenuGame");

        //currentState = GameState.START;

        isWin = false;

        StartCoroutine(TimingToStartGame(1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.START:
                {
                    //currentState = GameState.INGAME;
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
            case GameState.CUT_SCENE:
                {
                    cutScene.gameObject.SetActive(true);
                    progressBar.gameObject.SetActive(false);
                    cutScene.Play();
                    isWin = true;
                    currentState = GameState.GAME_OVER;
                }
                break;
            case GameState.OUT_TIME:
                {
                    //mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
                    currentState = GameState.CUT_SCENE;
                }
                break;
            case GameState.GAME_OVER:
                {
                    //mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
                    if (isWin)
                    {
                        StartCoroutine(TimingToShowPopUp(5));
                    }
                    else
                    {
                        StartCoroutine(TimingToShowPopUp(1));
                    }
                    currentState = GameState.WAITING;
                }
                break;
            case GameState.WAITING:
                {

                }
                break;
        }
    }
    IEnumerator TimingToShowPopUp(float time)
    {
        UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(time);
        bgEndGame.SetActive(true);
        mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
        cutScene.gameObject.SetActive(false);
        Debug.Log("ShowPopUp");
    }
    IEnumerator TimingToStartGame(float time)
    {
        yield return new WaitForSeconds(time);
        tutorialGame.SetActive(false);
        UI.gameObject.SetActive(true);
        currentState = GameState.INGAME;
    }
}
