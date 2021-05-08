using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Base;
using BatailleNavale.Base.Boats;
using BatailleNavale.Base.Entity;
using BatailleNavale.Blue.Entity;
using BatailleNavale.Blue.Factories;
using BatailleNavale.Red.Entity;
using BatailleNavale.Red.Factories;

namespace BatailleNavale.Game
{
	public class GameManager
	{
		#region Properties
		
		public bool GameOver { get; set; }

		public List<Player> Players;
		public Player CurrentPlayer;

		#endregion

		#region Constructor

		public GameManager()
		{
			BlueFactory blueFactory = new BlueFactory();
			RedFactory redFactory = new RedFactory();

			Players = new List<Player>();
			string errorMessage = string.Empty;

			Player bluePlayer = blueFactory.CreatePlayer();
			
			if (!bluePlayer.Board.AddBoat(blueFactory.CreateAircraftCarrier(), new Vector2Int(0, 0), Direction.Droite, out errorMessage))
				throw new Exception(errorMessage);
			if (!bluePlayer.Board.AddBoat(blueFactory.CreateCruiser(), new Vector2Int(3, 2), Direction.Bas, out errorMessage))
				throw new Exception(errorMessage);
			if (!bluePlayer.Board.AddBoat(blueFactory.CreateDestroyer(), new Vector2Int(1, 5), Direction.Bas, out errorMessage))
				throw new Exception(errorMessage);
			if (!bluePlayer.Board.AddBoat(blueFactory.CreateSubMarine(), new Vector2Int(8, 8), Direction.Gauche, out errorMessage))
				throw new Exception(errorMessage);
			if (!bluePlayer.Board.AddBoat(blueFactory.CreateTorpedoBoat(), new Vector2Int(9, 7), Direction.Haut, out errorMessage))
				throw new Exception(errorMessage);

			Player redPlayer = redFactory.CreatePlayer();
			if (!redPlayer.Board.AddBoat(redFactory.CreateTorpedoBoat(), new Vector2Int(0, 0), Direction.Bas, out errorMessage))
				throw new Exception(errorMessage);

			Players.Add(bluePlayer);
			Players.Add(redPlayer);

			CurrentPlayer = Players[0];
		} 

		#endregion

		public void RunGame()
		{
			while (!GameOver)
			{
				Console.Clear();
				Console.ForegroundColor = CurrentPlayer.Color;

				CurrentPlayer.Board.DisplayGrid();

				if (CurrentPlayer.GetType() == typeof(BluePlayer))
				{
					CurrentPlayer.Board.FireBoat(GetCoordinates(), Players[1].Board);
					GameOver = CurrentPlayer.Board.CheckVictory(Players[1].Board);
				}
				else
				{
					CurrentPlayer.Board.FireBoat(GetCoordinates(), Players[0].Board);
					GameOver = CurrentPlayer.Board.CheckVictory(Players[0].Board);
				}

				if (GameOver)
					DisplayVictory();
				else
					SwitchPayer();
			}
		}

		

		void DisplayVictory()
		{
			Console.Clear();
			string player = CurrentPlayer.GetType() == typeof(BluePlayer) ? "Blue" : "Red";

			Console.WriteLine($"Le joueur {player} gagne la partie.");
			Console.WriteLine("Félicitations!!");

			Console.ReadLine();
		}
		void SwitchPayer()
		{
			if (CurrentPlayer.GetType() == typeof(BluePlayer))
				CurrentPlayer = Players.Single(p => p.GetType() == typeof(RedPlayer));
			else
				CurrentPlayer = Players.Single(p => p.GetType() == typeof(BluePlayer));
		}
		string GetPlayerInput()
		{
			Console.WriteLine($"Joueur {CurrentPlayer} joue.");
			Console.WriteLine("Entrez les coordonnées de votre prochain tir: ");
			return Console.ReadLine();
		}
		Vector2Int GetCoordinates()
		{
			bool inputXAccepted = false;
			bool inputYAccepted = false;
			int x = 0;
			int y = 0;

			while (!inputXAccepted || !inputYAccepted)
			{
				string input = GetPlayerInput();
				string[] targetPosition = input.Split('-');
				inputXAccepted = int.TryParse(targetPosition[0], out x);
				inputYAccepted = int.TryParse(targetPosition[1], out y);
			}

			return new Vector2Int(x, y);
		}
	}
}