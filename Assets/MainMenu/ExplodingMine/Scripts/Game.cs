using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace MiniGames.ExplodingMine
{
    enum GameStateMine
    {
        WAITING,
        GUESS
    }
    public class Game : MonoBehaviour
    {
        public static Game Instance;

        public int gridIndexCurrent;

        //public bool isGameOver;

        public bool isChooseCorrect;

        //public bool startGame;
        public GameState currentState;
        Level level;

        [SerializeField]
        private ProgressBar progressBar;

        public GameObject mainMenu;

        [SerializeField]
        private GameObject tutorialGame;

        [SerializeField]
        private VideoPlayer cutScene;

        [SerializeField]
        private GameObject rawContent;

        [SerializeField]
        private GameObject bgEndGame;

        bool isWin;
        private void Awake()
        {
            Instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            gridIndexCurrent = 0;
            //isGameOver = false;
            isChooseCorrect = true;
            //startGame = false;
            isWin = false;
            level = Level.EASY;

            currentState = GameState.START;

            mainMenu = GameObject.Find("@MainMenuGame");

            StartCoroutine(TimingToStartGame(1.5f));
        }

        // Update is called once per frame
        void Update()
        {
            switch (currentState)
            {
                case GameState.START:
                    {
                        
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
                        //cutScene.gameObject.SetActive(true);
                        rawContent.SetActive(true);
                        progressBar.gameObject.SetActive(false);
                        cutScene.Play();
                        isWin = true;
                        currentState = GameState.GAME_OVER;
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

        private void OnDisable()
        {
            GameEvent.GameWon -= GameWon;
        }

        private void OnEnable()
        {
            GameEvent.GameWon += GameWon;
        }

        void GameWon()
        {
            //StartCoroutine(WinGameTimeWaitToFishPaht(popupGameWon));
            currentState = GameState.CUT_SCENE;
        }

        public IEnumerator WinGameTimeWaitToFishPath(GameObject ob)
        {
            yield return new WaitForSeconds(1);
            ob.gameObject.SetActive(true);
        }
        IEnumerator TimingToStartGame(float time)
        {
            yield return new WaitForSeconds(time);
            tutorialGame.SetActive(false);
            //UI.gameObject.SetActive(true);
            currentState = GameState.INGAME;
        }
        IEnumerator TimingToShowPopUp(float time)
        {
            //.gameObject.SetActive(false);
            yield return new WaitForSeconds(time);
            bgEndGame.SetActive(true);
            mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
            cutScene.gameObject.SetActive(false);
            rawContent.SetActive(false);
            Debug.Log("ShowPopUp");
        }
    }


}

