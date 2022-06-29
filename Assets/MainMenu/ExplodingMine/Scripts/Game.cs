using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGames.ExplodingMine
{
    public class Game : MonoBehaviour
    {
        public static Game Instance;

        public int gridIndexCurrent;

        public GameObject popupGameWon;
        private void Awake()
        {
            Instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            gridIndexCurrent = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (gridIndexCurrent == 15)
            {
                GameEvent.GameWon();
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
            StartCoroutine(WinGameTimeWaitToFishPaht());
        }
        public void GameReTry()
        {
            SceneManager.LoadScene("ExplodingMine");
        }

        IEnumerator WinGameTimeWaitToFishPaht()
        {
            yield return new WaitForSeconds(2);
            popupGameWon.gameObject.SetActive(true);
        }
    }
}
