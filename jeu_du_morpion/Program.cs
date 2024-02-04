// See https://aka.ms/new-console-template for more information

bool inGame = true;
string player1 = "";
string player2 = "";
int positionRowSymbolX = 0;
int positionColSymbolX = 0;
int positionRowSymbolO = 0;
int positionColSymbolO = 0;
char player1Symbol = 'X';
char player2Symbol = 'O';

char[,] boardGame =
    {
    {'.', '.', '.' },
    {'.', '.', '.' },
    {'.', '.', '.' }
};

Console.WriteLine("Joueur 1, entrez votre prénom :");
player1 = Console.ReadLine();

Console.WriteLine("Joueur 2, entrez votre prénom :");
player2 = Console.ReadLine();

Console.Clear();

Console.WriteLine($"{player1} vous jouerez avec les {player1Symbol}");
Console.WriteLine($"{player2} vous jouerez avec les {player2Symbol}");




while (inGame)
{
    DisplayBoard(boardGame);
    Console.WriteLine();
    PlayerTurn(player1, positionRowSymbolX, positionColSymbolX, player1Symbol);
    if (CheckForWin(player1Symbol))
    {
        Console.WriteLine($"\nBravo {player1} vous avez gagné !!!");
        break;
    }

    PlayerTurn(player2, positionRowSymbolO, positionColSymbolO, player2Symbol);
    if (CheckForWin(player2Symbol))
    {
        Console.WriteLine($"\nBravo {player2} vous avez gagné !!!");
        break;
    }
    Console.Clear();
}


static void DisplayBoard(char[,] board) {

    Console.WriteLine("\n\n   1  |  2  |  3  ");
    Console.WriteLine();
    Console.WriteLine($"1  {board[0,0]}  |  {board[0,1]}  |  {board[0,2]}");
    Console.WriteLine("      |     |    ");
    Console.WriteLine("  ----+-----+----");
    Console.WriteLine("      |     |    ");
    Console.WriteLine($"2  {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}");
    Console.WriteLine("      |     |    ");
    Console.WriteLine("  ----+-----+----");
    Console.WriteLine($"3  {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}");
    Console.WriteLine("      |     |    ");
    
}

bool CheckForWin(char playerSymbol)
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

void PlayerTurn(string playerName, int playerSymbolX, int playerSymbolY, char playerSymbolDisplay)
{
    Console.WriteLine($"\n {playerName} , veuillez indiquer le numéro de ligne où placer votre symbole");
    playerSymbolX = GetPlayerInput();

    Console.WriteLine("\nVeuillez maintenant indiquer le numéro de la colonne où placer votre symbole");
    playerSymbolY = GetPlayerInput();

    if (boardGame[playerSymbolX - 1, playerSymbolY - 1] != '.')
    {
        Console.WriteLine("\nVous ne pouvez pas choisir cette case");

        Console.WriteLine("\n\nJoueur 1, veuillez indiquer le numéro de ligne où placer votre symbole");
        playerSymbolX = GetPlayerInput();

        Console.WriteLine("\nJoueur 1, veuillez indiquer le numéro de la colonne où placer votre symbole");
        playerSymbolY = GetPlayerInput();
    }
    boardGame[playerSymbolX - 1, playerSymbolY - 1] = playerSymbolDisplay;
    Console.Clear();

    DisplayBoard(boardGame);

}

int GetPlayerInput()
{
    string input = Console.ReadLine();
    return int.Parse(input);

}

