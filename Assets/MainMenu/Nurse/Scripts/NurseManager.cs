using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class NurseManager : MonoBehaviour
{
    public static NurseManager Instance { set; get; }


    // Start is called before the first frame update
    private GameObject mainMenu;

    [SerializeField]
    private ProgressBar progressBar;

    [SerializeField]
    private VideoPlayer cutScene;
    public int number; 

    private GameState currentState;

    bool isWin;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentState = GameState.START;

        mainMenu = GameObject.Find("@MainMenuGame");

        number = 0;

        isWin = false;
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
                    if(number == 7)
                    {
                        currentState = GameState.CUT_SCENE;
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
                    if(isWin)
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
}
