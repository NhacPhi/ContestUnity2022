using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
namespace MiniGames.KillingNurse
{
    public class GameNurse : MonoBehaviour
    {
        private float width = 7.5f;
        private float height = 4f;
        [SerializeField]
        private SpawnExPosion spawns;

        private Level level;
        public GameState currentState;

        private GameObject mainMenu;
        [SerializeField]
        private ProgressBar progressBar;

        [SerializeField]
        private VideoPlayer cutScene;

        [SerializeField]
        private GameObject tutorial;

        [SerializeField]
        private Canvas UI;

        public bool isWin;

        [SerializeField]
        private GameObject bgEndGame;

        // Start is called before the first frame update
        void Start()
        {
            level = Level.EASY;
            currentState = GameState.START;
            Time.timeScale = 1;
            mainMenu = GameObject.Find("@MainMenuGame");
            StartCoroutine(WaitTimeToSpawnExposion());
            StartCoroutine(TimingToStartGame(1.5f));
        }

        // Update is called once per frame
        void Update()
        {
            switch(currentState)
            {
                case GameState.START:
                    {
                       // currentState = GameState.INGAME;
                    }
                    break;
                case GameState.INGAME:
                    {
                        if(spawns.CheckGameOver())
                        {
                            spawns.PauseExposion();
                            mainMenu.GetComponent<MainMenuManager>().DecreaseHealth();
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
                        currentState = GameState.CUT_SCENE;
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
                        // mainMenu.GetComponent<MainMenuManager>().ShowPopupHealth();
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
        IEnumerator WaitTimeToSpawnExposion()
        {
            yield return new WaitForSeconds(1.5f);
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                GameObject ob;
                if (SpawnExPosion.Instance.GetPooledExposion() != null)
                {
                    ob = SpawnExPosion.Instance.GetPooledExposion();
                    do
                    {
                        float widthOb = Random.Range(-width, width);
                        float heightOb = Random.Range(-height, height);
                        ob.transform.position = new Vector3(widthOb, heightOb);
                    } while (!SpawnExPosion.Instance.ExposionCanBePlace(ob.transform.position));

                    ob.gameObject.SetActive(true);
                    ob.gameObject.GetComponent<ExPosion>().isActive = true;
                    ob.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                }
               
            }

        }

        IEnumerator TimingToStartGame(float time)
        {
            yield return new WaitForSeconds(time);
            tutorial.SetActive(false);
            UI.gameObject.SetActive(true);
            currentState = GameState.INGAME;
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
    }

}
