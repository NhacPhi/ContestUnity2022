using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareIndicate : MonoBehaviour
{
    public int[,] square_data = new int[5, 5];
    private int number = 4;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSquareData();
    }

    void GenerateSquareData()
    {
        int index = 0;
        for (int row = 0; row < number; row++)
            for (int column = 0; column < number; column++)
            {
                square_data[row, column] = index;
                index++;
            }
    }
    public (int, int) GetSquarePosition(int squareIndex)
    {
        int pos_row = -1;
        int pos_col = -1;
        for (int row = 0; row < number; row++)
        {
            for (int column = 0; column < number; column++)
            {
                if (square_data[row, column] == squareIndex)
                {
                    pos_row = row;
                    pos_col = column;
                }
            }
        }
        return (pos_row, pos_col);
    }
    public int GetSquareIndex(int row, int column)
    {
        return square_data[row,column];
    }
}
