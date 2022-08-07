using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MiniGames.ExplodingMine
{
    public class Grid : MonoBehaviour
    {
        [SerializeField]
        private int columns;

        [SerializeField]
        private int rows;

        [SerializeField]
        private GameObject gridSquare;

        private List<GameObject> gridSquares = new List<GameObject>();

        [SerializeField]
        private float squareScale;

        [SerializeField]
        private float everySquareOffset;

        private Vector2 offset;

        [SerializeField]
        private float squareGap;

        [SerializeField]
        private Vector2 startPosition;

        [SerializeField]
        private PlayerMovement player;

        //[SerializeField]
        //private Sprite destinationImage;


        private int topSquareIndex;
        private int bottomSquareIndex;
        private int rightSquareIndex;

        [SerializeField]
        private SquareIndicate squareIndicate;

        private List<List<int>> listArray;

        private List<int> listSquarePath;

        int randomNumber;
        // Start is called before the first frame update
        void Start()
        {

            CreateGrid();
            listArray = new List<List<int>>
            {
                new List<int>{0, 4, 5, 6, 10, 14, 15},
                new List<int>{0, 1, 2, 6, 10, 11, 15},
                new List<int>{0, 1, 5, 9, 10, 14, 15},
                new List<int>{0, 4, 8, 9, 10, 11, 15},
            };
            randomNumber = Random.Range(0, listArray.Count);
            listSquarePath = listArray[randomNumber];
            StartCoroutine(WaiteToShowPath());
            //SetGridSquaresPosition();
            //SetEndPointOfPlayer();


        }

        // Update is called once per frame
        void Update()
        {
            //if(Game.Instance.gridIndexCurrent != 0)
            //{
            //    SetEndPointOfPlayer();
            //}
            //SetSquareCanActive();
        }
        void CreateGrid()
        {
            SpawnGridSquare();
            SetGridSquaresPosition();
        }

        private void OnEnable()
        {
            GameEvent.CheckAllSquareInGridCanBeActive += SetGridSquaresPosition;
            GameEvent.GameOver += CheckGameOver;
            GameEvent.ChooseSquare += SetEndPointOfPlayer;
            GameEvent.ChooseSquare += SetSquareCanActive;
        }

        private void OnDisable()
        {
            GameEvent.CheckAllSquareInGridCanBeActive -= SetGridSquaresPosition;
            GameEvent.GameOver -= CheckGameOver;
            GameEvent.ChooseSquare -= SetEndPointOfPlayer;
            GameEvent.ChooseSquare -= SetSquareCanActive; ;
        }

        private void SpawnGridSquare()
        {
            int square_index = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    gridSquares.Add(Instantiate(gridSquare) as GameObject);
                    gridSquares[gridSquares.Count - 1].GetComponent<GridSquare>().squareIndex = square_index;
                    gridSquares[gridSquares.Count - 1].transform.SetParent(this.transform);
                    gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
                    gridSquares[gridSquares.Count - 1].GetComponent<GridSquare>().SetImage(square_index % 2 == 0);
                    square_index++;
                }
            }
            gridSquares[0].gameObject.GetComponent<GridSquare>().activeImage.gameObject.SetActive(true);
            //gridSquares[gridSquares.Count - 1].gameObject.GetComponent<GridSquare>().normalImage.gameObject.GetComponent<Image>().sprite = destinationImage;
            gridSquares[gridSquares.Count - 1].gameObject.GetComponent<GridSquare>().SetDestinationImage();
        }

        private void SetGridSquaresPosition()
        {
            int column_number = 0;
            int row_number = 0;

            Vector2 square_gap_number = new Vector2(0, 0);
            bool row_moved = false;

            var square_rect = gridSquares[0].GetComponent<RectTransform>();
            offset.x = square_rect.rect.width * square_rect.transform.localScale.x + everySquareOffset;
            offset.y = square_rect.rect.height * square_rect.transform.localScale.y + everySquareOffset;

            foreach (GameObject square in gridSquares)
            {
                if (column_number + 1 > columns)
                {
                    square_gap_number.x = 0;
                    // Go to the next column
                    column_number = 0;
                    row_number++;
                    row_moved = false;
                }

                var pos_x_offset = offset.x * column_number + (square_gap_number.x * squareGap);
                var pos_y_offset = offset.y * row_number + (square_gap_number.y * squareGap);

                if (column_number > 0 && column_number % 3 == 0)
                {
                    square_gap_number.x++;
                    pos_x_offset += squareGap;
                }
                if (row_number > 0 && row_number % 3 == 0 && row_moved == false)
                {
                    row_moved = true;
                    square_gap_number.y++;
                    pos_y_offset += squareGap;
                }

                square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x + pos_x_offset,
                    startPosition.y - pos_y_offset);
                square.GetComponent<RectTransform>().localPosition = new Vector3(startPosition.x + pos_x_offset,
                    startPosition.y - pos_y_offset, 0);
                column_number++;
            }
        }
        public void SetEndPointOfPlayer()
        {
            foreach (GameObject square in gridSquares)
            {
                if(square.gameObject.GetComponent<GridSquare>().squareIndex == Game.Instance.gridIndexCurrent)
                {
                    //player.SetEndpoint(square.gameObject.GetComponent<Transform>().position);
                    player.listPoint.Add(square.gameObject.GetComponent<Transform>().position);
                    player.nextPoint++;
                }
            }

        }
        public void SetSquareCanActive()
        {
            foreach (var square in gridSquares)
            {
                square.GetComponent<GridSquare>().canActive = false;
            }
            int row = 0;
            int col = 0;
            row = squareIndicate.GetSquarePosition(Game.Instance.gridIndexCurrent).Item1;
            col = squareIndicate.GetSquarePosition(Game.Instance.gridIndexCurrent).Item2;
            if(row != 0 && col != 0 && row != 4 && col != 4)
            {
                topSquareIndex = squareIndicate.GetSquareIndex(row - 1,col);
                bottomSquareIndex = squareIndicate.GetSquareIndex(row + 1, col);
                rightSquareIndex = squareIndicate.GetSquareIndex(row, col + 1);
            }
            else if(row == 0 && col < 4)
            {
                topSquareIndex = squareIndicate.GetSquareIndex(row, col);
                bottomSquareIndex = squareIndicate.GetSquareIndex(row + 1, col);
                rightSquareIndex = squareIndicate.GetSquareIndex(row, col + 1);
            }
            else if(col == 0 && row < 4)
            {
                Debug.Log("AAA");
                topSquareIndex = squareIndicate.GetSquareIndex(row, col);
                bottomSquareIndex = squareIndicate.GetSquareIndex(row + 1, col);
                rightSquareIndex = squareIndicate.GetSquareIndex(row, col + 1);
            }
            else if(col == 4 && row < 4)
            {
                topSquareIndex = squareIndicate.GetSquareIndex(row, col);
                bottomSquareIndex = squareIndicate.GetSquareIndex(row + 1, col);
                rightSquareIndex = squareIndicate.GetSquareIndex(row, col);
            }
            else if(row == 4 && col < 3)
            {
                topSquareIndex = squareIndicate.GetSquareIndex(row - 1, col);
                bottomSquareIndex = squareIndicate.GetSquareIndex(row, col);
                rightSquareIndex = squareIndicate.GetSquareIndex(row, col + 1);
            }
            gridSquares[topSquareIndex].GetComponent<GridSquare>().canActive = true;
            gridSquares[bottomSquareIndex].GetComponent<GridSquare>().canActive = true;
            gridSquares[rightSquareIndex].GetComponent<GridSquare>().canActive = true;

            player.fishPoint = gridSquares[gridSquares.Count - 1].GetComponent<Transform>().position;
            Debug.Log("Player fish point: " + player.fishPoint);
        } 

        IEnumerator WaiteToShowPath()
        {
            yield return new WaitForSeconds(2f);
            foreach(var index in listArray[randomNumber])
            {
                gridSquares[index].GetComponent<GridSquare>().preditionImage.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                gridSquares[index].GetComponent<GridSquare>().preditionImage.gameObject.SetActive(false);
            }
            Game.Instance.currentState = GameState.INGAME;
            SetSquareCanActive();
        }
        void CheckGameOver()
        {
            bool isGameOver = true;
            foreach(int index in listSquarePath)
            {
                if(Game.Instance.gridIndexCurrent == index)
                {
                    isGameOver = false;
                }
            }

            if(isGameOver)
            {
                Game.Instance.isChooseCorrect = false;
                Game.Instance.mainMenu.GetComponent<MainMenuManager>().DecreaseHealth();
                Game.Instance.currentState = GameState.GAME_OVER;
                //StartCoroutine(Game.Instance.WinGameTimeWaitToFishPaht(Game.Instance.popupEndGames));
            }
        }
    }

}
