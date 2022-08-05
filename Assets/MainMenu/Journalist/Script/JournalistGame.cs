using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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

    [SerializeField]
    private VideoPlayer cutScene;


    public bool isWin;


    [SerializeField]
    private GameObject tutorial;

    [SerializeField]
    private Canvas UI;

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
        StartCoroutine(TimingToStartGame(1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
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
            case GameState.OUT_TIME:
                {
                    mainMenu.GetComponent<MainMenuManager>().DecreaseHealth();
                    currentState = GameState.GAME_OVER;
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
            case GameState.GAME_OVER:
                {
                    Debug.Log("Game Over");
                    //mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
                    if (isWin)
                    {
                        StartCoroutine(TimingToShowPopUp(5));
                    }
                    else
                    {
                        StartCoroutine(TimingToShowPopUp(0));
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
        yield return new WaitForSeconds(time);
        mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
        Debug.Log("ShowPopUp");
    }
    IEnumerator TimingToStartGame(float time)
    {
        yield return new WaitForSeconds(time);
        tutorial.SetActive(false);
        UI.gameObject.SetActive(true);
    currentState = GameState.INGAME;
    }
}
