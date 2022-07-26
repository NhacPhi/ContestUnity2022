using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            level = Level.EASY;

            currentState = GameState.START;

            mainMenu = GameObject.Find("@MainMenuGame");
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
            currentState = GameState.GAME_OVER;
        }

        public IEnumerator WinGameTimeWaitToFishPath(GameObject ob)
        {
            yield return new WaitForSeconds(1);
            ob.gameObject.SetActive(true);
        }
    }
}

