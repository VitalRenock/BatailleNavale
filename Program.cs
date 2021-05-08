using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Red.Factories;
using BatailleNavale.Blue.Factories;
using BatailleNavale.Game;

namespace BatailleNavale
{
	class Program
	{
		static void Main(string[] args)
		{
			GameManager gameManager = new GameManager();
			gameManager.RunGame();

			Console.Clear();
			Console.WriteLine("Fin du jeu, merci d'avoir joué!");
			Console.ReadLine();
		}
	}
}
