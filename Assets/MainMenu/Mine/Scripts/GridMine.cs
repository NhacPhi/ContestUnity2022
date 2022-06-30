using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.Mine
{
    public class GridMine : MonoBehaviour
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
        // Start is called before the first frame update
        void Start()
        {
            CreateGrid();
            StartCoroutine(TimeToShowPreditionSquare());
            //SetGridSquaresPosition();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void CreateGrid()
        {
            SpawnGridSquare();
            SetGridSquaresPosition();
        }
        private void SpawnGridSquare()
        {
            int square_index = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    gridSquares.Add(Instantiate(gridSquare) as GameObject);
                    gridSquares[gridSquares.Count - 1].GetComponent<GridSquareMine>().squareIndex = square_index;
                    gridSquares[gridSquares.Count - 1].transform.SetParent(this.transform);
                    gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
                    gridSquares[gridSquares.Count - 1].GetComponent<GridSquareMine>().SetImage(square_index % 2 == 0);
                    square_index++;
                }
            }
        
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


        IEnumerator TimeToShowPreditionSquare()
        {
            yield return new WaitForSeconds(1f);
            foreach (int index in GameMine.Instance.listIndexs)
            {
                gridSquares[index].GetComponent<GridSquareMine>().preditionImage.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.8f);
                gridSquares[index].GetComponent<GridSquareMine>().preditionImage.gameObject.SetActive(false);
            }
            foreach(var square in gridSquares)
            {
                square.GetComponent<GridSquareMine>().canActive = true;
            }
        }
    }
}

