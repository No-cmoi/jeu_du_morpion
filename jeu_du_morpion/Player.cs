using System;
namespace jeu_du_morpion
{
	public class Player
	{
        public string Name { get; set; }
		public char Symbol { get; set; }

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public void AnnounceWinner()
        {
            Console.WriteLine($"\nBravo {Name} vous avez gagné !!");
        }
	}

}

