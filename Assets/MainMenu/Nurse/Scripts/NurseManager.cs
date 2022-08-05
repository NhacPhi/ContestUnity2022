using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class NurseManager : MonoBehaviour
{
    public static NurseManager Instance { set; get; }

    public List<GameObject> shapes;

    public List<Transform> points;

    // Start is called before the first frame update
    private GameObject mainMenu;

    [SerializeField]
    private ProgressBar progressBar;

    [SerializeField]
    private VideoPlayer cutScene;
    public int number;

    private List<int> numbers = new List<int> () { 0, 1, 2, 3, 4, 5, 6 };

    private GameState currentState;

    bool isWin;

    [SerializeField]
    private GameObject tutorial;

    [SerializeField]
    private Canvas UI;
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

        for(int i = 0; i < 3 ; i++)
        {
            int index = Random.Range(0, numbers.Count);
            GameObject ob = Instantiate(shapes[index], points[i].position, Quaternion.identity);
            shapes.RemoveAt(index);
            numbers.RemoveAt(index);
        }

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
                    if(number == 3)
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
    IEnumerator TimingToStartGame(float time)
    {
        yield return new WaitForSeconds(time);
        tutorial.SetActive(false);
        UI.gameObject.SetActive(true);
        currentState = GameState.INGAME;
    }
}
