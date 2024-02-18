using System;
namespace jeu_du_morpion
{
    public class Grid
    {
        public static char[,] boardGame =
        {

        {'.', '.', '.' },
        {'.', '.', '.' },
        {'.', '.', '.' }
        };

        public void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("\n\n   1  |  2  |  3  ");
            Console.WriteLine();
            Console.WriteLine($"1  {boardGame[0, 0]}  |  {boardGame[0, 1]}  |  {boardGame[0, 2]}");
            Console.WriteLine("      |     |    ");
            Console.WriteLine("  ----+-----+----");
            Console.WriteLine("      |     |    ");
            Console.WriteLine($"2  {boardGame[1, 0]}  |  {boardGame[1, 1]}  |  {boardGame[1, 2]}");
            Console.WriteLine("      |     |    ");
            Console.WriteLine("  ----+-----+----");
            Console.WriteLine($"3  {boardGame[2, 0]}  |  {boardGame[2, 1]}  |  {boardGame[2, 2]}");
            Console.WriteLine("      |     |    ");
        }

        public bool CheckForWin(char playerSymbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (boardGame[i, 0] == playerSymbol && boardGame[i, 1] == playerSymbol && boardGame[i, 2] == playerSymbol)
                    return true;

                if (boardGame[0, i] == playerSymbol && boardGame[1, i] == playerSymbol && boardGame[2, i] == playerSymbol)
                    return true;
            }

            if (boardGame[0, 0] == playerSymbol && boardGame[1, 1] == playerSymbol && boardGame[2, 2] == playerSymbol)
                return true;

            if (boardGame[2, 0] == playerSymbol && boardGame[1, 1] == playerSymbol && boardGame[0, 2] == playerSymbol)
                return true;

            return false;
        }

        public bool DrawGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boardGame[i, j] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool PlaceSymbolOnGrid(int row, int col, char symbol)
        {
            if (boardGame[row - 1, col - 1] != '.')
            {
                Console.WriteLine("\nVous ne pouvez pas choisir cette case");
                return false;
            }
            boardGame[row - 1, col - 1] = symbol;
            DisplayBoard();
            
            return true;
        }
    }
}

