using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MiniGame{
    AIR_CRAFT_CRASH = 0,
    EXPLODING_BUILDING,
    EXPLODING_MINE,
    JOURNALIST,
    KILLING_NURSE,
    NURSE,
    MINE
}
public class MainMenuManager : MonoBehaviour
{
    public MainMenuManager Instance { get; set; }

    private List<MiniGame> miniGames;

    private MiniGame currentMiniGame;

    [SerializeField]
    private GameObject popupHealth;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        miniGames = new List<MiniGame>() { MiniGame.AIR_CRAFT_CRASH ,
        //MiniGame.EXPLODING_BUILDING,
        MiniGame.EXPLODING_MINE,
        MiniGame.JOURNALIST,
        MiniGame.KILLING_NURSE,
        MiniGame.NURSE,
        MiniGame.MINE
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        AudioManager.Instance.PlayMusicMiniGame();
        if(GameManager.Instance.currentState != GameState.GAME_OVER)
        {
            popupHealth.gameObject.SetActive(false);
            RandomMiniGame();
            switch (currentMiniGame)
            {
                case MiniGame.AIR_CRAFT_CRASH:
                    {
                        SceneManager.LoadScene(Define.AIR_CRAFT_CRASH);
                    }
                    break;
                case MiniGame.EXPLODING_MINE:
                    {
                        SceneManager.LoadScene(Define.EXPLODING_MINE);
                    }
                    break;
                case MiniGame.JOURNALIST:
                    {
                        SceneManager.LoadScene(Define.JOURNALIST);
                    }
                    break;
                case MiniGame.NURSE:
                    {
                        SceneManager.LoadScene(Define.NURSE);
                    }
                    break;
                case MiniGame.KILLING_NURSE:
                    {
                        SceneManager.LoadScene(Define.KILLING_NURSE);
                    }
                    break;
                case MiniGame.MINE:
                    {
                        SceneManager.LoadScene(Define.MINE);
                    }
                    break;
                default:
                    {
                        SceneManager.LoadScene(Define.EXPLODING_MINE);
                    }
                    break;
            }
        }
            
       else if(GameManager.Instance.currentState == GameState.GAME_OVER)
        {
            if(!GameManager.Instance.isWin)
            {
                GameManager.Instance.currentState = GameState.WAITING;
                SceneManager.LoadScene(Define.MAIN_MENU);
            }

        }

    }
    void RandomMiniGame()
    {
        if(miniGames.Count == 0)
        {
            //miniGames = new List<MiniGame>() { MiniGame.AIR_CRAFT_CRASH ,
            //MiniGame.EXPLODING_BUILDING,
            //MiniGame.EXPLODING_MINE,
            //MiniGame.JOURNALIST,
            //MiniGame.KILLING_NURSE,
            //MiniGame.NURSE,
            //MiniGame.MINE
            GameManager.Instance.isWin = true;
            GameManager.Instance.currentState = GameState.CUT_SCENE;
            return ;
        }
        MiniGame miniGame = 0;
        int numberIndex = Random.Range(0, miniGames.Count);
        miniGame = miniGames[numberIndex];
        currentMiniGame = miniGame;
        miniGames.RemoveAt(numberIndex);
        Debug.Log("MiniGames: " + miniGames);
        //scurrentMiniGame = miniGame;
    }

    public void ShowPopupHealth()
    {
        StartCoroutine(TimingForShowPopup());
    }
    public void DecreaseHealth()
    {
        popupHealth.gameObject.GetComponent<HeartManager>().DescreaseHeart();
    }
    IEnumerator TimingForShowPopup()
    {
        yield return new WaitForSeconds(1);
        popupHealth.SetActive(true);
        yield return new WaitForSeconds(4);
        PlayGame();
    }
}
