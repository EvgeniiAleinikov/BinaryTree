using System;

namespace dotNetTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = CheckAllBoards() ? "OK!" : "One or more board failed to check.";
            Console.WriteLine(result);
            Console.ReadLine();
        }

        /// <summary>
        /// Insert your code here
        /// </summary>
        /// <param name="array">9*9 char array</param>
        /// <returns></returns>
        static bool CheckBoardIfSudoku(char[,] array)
        {

            return RowAndColumnCheck(array) == SquareCheck(array) == true;
        }

        static public bool CheckArray(char[] array)
        {
            if (IsUniq(array))
            {
                return true;
            }
            return false;
        }

        static public bool IsUniq(char[] array)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = i + 1; j < 9 && array[i] != '.'; j++)
                {
                    if (array[i] == array[j])
                        return false;
                }
            }
            return true;
        }

        static public bool RowAndColumnCheck(char[,] array)
        {
            char[] testRow = new char[9];
            char[] testColumn = new char[9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    testRow[j] = array[j, i];
                    testColumn[j] = array[i, j];
                }
                if (!CheckArray(testRow) || !CheckArray(testColumn))
                {
                    return false;
                }
            }
            return true;
        }

        static public bool SquareCheck(char[,] array)
        {
            char[] testSquare = new char[9];
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    for (int ik = i; ik < i + 3; ++ik)
                    {
                        for (int jk = j; jk < j + 3; ++jk)
                        {
                            testSquare[(ik-i)*3 + jk-j] = array[ik , jk];
                        }
                    }
                }
                if (!CheckArray(testSquare))
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckAllBoards()
        {
            var boardValid1 = new char[9, 9]{    { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                                 { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                                                 { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                                 { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                                 { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                                 { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                                 { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                                 { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                                 { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
            var trueResult = CheckBoardIfSudoku(boardValid1);
            var boardValid2 = new char[9, 9]{    { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' } };
            var trueResult2 = CheckBoardIfSudoku(boardValid2);
            var boardInValid1 = new char[9, 9]{  { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                                 { '6', '.', '5', '1', '9', '5', '.', '.', '.' },
                                                 { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                                 { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                                 { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                                 { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                                 { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                                 { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                                 { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
            var falseResult1 = CheckBoardIfSudoku(boardInValid1);
            var boardInValid2 = new char[9, 9]{  { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                                 { '6', '.', '2', '1', '9', '5', '.', '.', '.' },
                                                 { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                                 { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                                 { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                                 { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                                 { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                                 { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                                 { '6', '.', '.', '.', '8', '.', '.', '7', '9' } };
            var falseResult2 = CheckBoardIfSudoku(boardInValid2);
            var boardInValid3 = new char[9, 9]{  { '5', '3', '.', '.', '7', '.', '.', '.', '3' },
                                                 { '6', '.', '5', '1', '9', '5', '.', '.', '.' },
                                                 { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                                 { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                                 { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                                 { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                                 { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                                 { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                                 { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
            var falseResult3 = CheckBoardIfSudoku(boardInValid3);
            var boardInValid4 = new char[9, 9]{  { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '1', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '1' } };
            var falseResult4 = CheckBoardIfSudoku(boardInValid4);
            return trueResult && trueResult2 && !falseResult1 && !falseResult2 && !falseResult3 && !falseResult4;
        }
    }
}
