using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGames.ExplodingMine
{
    enum GameState
    {
        WAITING,
        GUESS
    }
    public class Game : MonoBehaviour
    {
        public static Game Instance;

        public int gridIndexCurrent;

        public GameObject popupGameWon;

        public GameObject popupEndGames;
        public bool isGameOver;

        public bool isChooseCorrect;

        public bool startGame;
        private void Awake()
        {
            Instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            gridIndexCurrent = 0;
            isGameOver = false;
            isChooseCorrect = true;
            startGame = false;
        }

        // Update is called once per frame
        void Update()
        {

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
            StartCoroutine(WinGameTimeWaitToFishPaht(popupGameWon));
        }
        public void GameReTry()
        {
            SceneManager.LoadScene("ExplodingMine");
        }

        public IEnumerator WinGameTimeWaitToFishPaht(GameObject ob)
        {
            yield return new WaitForSeconds(1);
            ob.gameObject.SetActive(true);
        }
    }
}

