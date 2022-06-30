using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace MiniGames.Mine
{
    public class GameMine : MonoBehaviour
    {
        public static GameMine Instance;
        // Start is called before the first frame update
        public List<int> listIndexs;

        private List<int> randomList; 

        public int currentIndex;

        public bool isChooseCorrect;

        [SerializeField]
        private GameObject popupGameOver;

        [SerializeField]
        private GameObject popupGameWon;

        public bool isCanSelect;

        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            isChooseCorrect = true;
            isCanSelect = true;
            randomList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            listIndexs = new List<int>() { 0, 0, 0, 0 };
            SetRandomValueOfListIndex();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDisable()
        {
            GameEvetMine.CheckGameOver -= CheckGameOver;
        }

        private void OnEnable()
        {
            GameEvetMine.CheckGameOver += CheckGameOver;
        }

        void CheckGameOver()
        {
            bool gameOver = true;
            int indexSquare = -1;
            Debug.Log("Current Square Index: " + currentIndex);
            foreach(int index in listIndexs)
            {
                if(currentIndex == index)
                {
                    gameOver = false;
                    indexSquare = index;
                }
            }
            if(gameOver)
            {
                isChooseCorrect = false;
                isCanSelect = false;
                StartCoroutine(WaitTimeForEndGame(popupGameOver));
            }

            if(listIndexs.Count > 0)
            {
                if (indexSquare != -1)
                {
                    listIndexs.Remove(indexSquare);
                }
            }
            if (listIndexs.Count == 0)
            {
                isCanSelect = false;
                StartCoroutine(WaitTimeForEndGame(popupGameWon));
                Debug.Log("Win");
            }

        }
        public void GameReTry()
        {
            SceneManager.LoadScene("Mine");
        }

        IEnumerator WaitTimeForEndGame(GameObject ob)
        {
            yield return new WaitForSeconds(1f);
            ob.gameObject.SetActive(true);
        }
        void SetRandomValueOfListIndex()
        {
            int number = 13;
            for(int i = 0; i < 4; i++)
            {
                int valueIndex = Random.Range(0, number);
                listIndexs[i] = randomList[valueIndex];
                randomList.Remove(randomList[valueIndex]);
                number--;
            }
        }
    }
}

