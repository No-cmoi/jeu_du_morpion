using jeu_du_morpion;

internal class Program
{
    private static void Main(string[] args)
    {
        bool replay = true;

        while (replay)
        {
            PlayingGame();

            Console.WriteLine("Voulez vous jouer une nouvelle partie ? oui / non ?");
            string userAnswer = Console.ReadLine().ToLower();
            replay = (userAnswer == "oui");
            Console.Clear();
        }
    }
    public static void PlayingGame()
    {


        Console.WriteLine("Joueur 1, entrez votre prénom :");
        Player player1 = new Player(Console.ReadLine(), 'X');

        Console.WriteLine("Joueur 2, entrez votre prénom :");
        Player player2 = new Player(Console.ReadLine(), 'O');

        Grid gameGrid = new Grid();

        Console.Clear();

        Console.WriteLine($"{player1} vous jouerez avec les {player1.Symbol}");
        Console.WriteLine($"{player2} vous jouerez avec les {player2.Symbol}");




        while (true)
        {
            gameGrid.DisplayBoard();

            Console.WriteLine();

            PlayerTurn(player1, gameGrid);
            if (gameGrid.CheckForWin(player1.Symbol))
            {
                player1.AnnounceWinner();
                break;
            }
            else if (gameGrid.DrawGame())
            {
                Console.WriteLine("Match nul !");
                break;
            }

            PlayerTurn(player2, gameGrid);
            if (gameGrid.CheckForWin(player2.Symbol))
            {
                player2.AnnounceWinner();
                break;
            }
            else if (gameGrid.DrawGame())
            {
                Console.WriteLine("Match nul !!");
                break;
            }

            Console.Clear();
        }

    }

        static void PlayerTurn(Player player, Grid grid)
        {
            Console.WriteLine($"\n {player.Name} , veuillez indiquer le numéro de ligne où placer votre symbole");
            int row  = GetPlayerInput();

            Console.WriteLine("\nVeuillez maintenant indiquer le numéro de la colonne où placer votre symbole");
            int col = GetPlayerInput();

            while (!grid.PlaceSymbolOnGrid(row, col, player.Symbol))
            {
                Console.WriteLine($"\n{player.Name}, veuillez indiquer le numéro de ligne où placer votre symbole");
                row = GetPlayerInput();

                Console.WriteLine($"\n{player.Name}, veuillez indiquer le numéro de la colonne où placer votre symbole");
                col = GetPlayerInput();

            }
        }

        static int GetPlayerInput()
        {
            string input = Console.ReadLine();
            return int.Parse(input);

        }
    
}