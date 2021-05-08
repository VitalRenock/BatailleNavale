using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Base;
using BatailleNavale.Base.Boats;

namespace BatailleNavale.Game
{
	public class Board
	{
		public char seaSymbol = '~';
		public char deathSymbol = 'x';

		public char[,] Grid;
		public List<Boat> Boats { get; set; }

		#region Constructor

		public Board(int gridSizeX, int gridSizeY)
		{
			Grid = new char[gridSizeX, gridSizeY];
			Boats = new List<Boat>();

			// Start Feed Grid
			for (int x = 0; x < Grid.GetLength(0); x++)
				for (int y = 0; y < Grid.GetLength(1); y++)
					Grid[x, y] = seaSymbol;
		}

		#endregion

		public bool FireBoat(Vector2Int firePosition, Board ennemyBoard)
		{
			if (ennemyBoard.Grid[firePosition.X, firePosition.Y] != seaSymbol)
			{
				ennemyBoard.Grid[firePosition.X, firePosition.Y] = deathSymbol;
				return true;
			}
			else
				return false;
		}

		public bool AddBoat(Boat boat, Vector2Int startPosition, Direction direction, out string errorMessage)
		{
			errorMessage = string.Empty;
			if (CheckGridLimits(boat, startPosition, direction))
			{
				errorMessage = "Impossible d'ajouter un bateau à cet emplacement car il est hors-limite.";
				return false;
			}

			switch (direction)
			{
				case Direction.Haut:
					for (int i = 0; i < boat.BoatSize; i++)
						if (Grid[startPosition.X, startPosition.Y - i] == seaSymbol)
							Grid[startPosition.X, startPosition.Y - i] = boat.BoatSymbol;
						else
							errorMessage = "Impossible d'ajouter un bateau à cet emplacement car il est déjà occupé.";
					break;
				case Direction.Bas:
					for (int i = 0; i < boat.BoatSize; i++)
						if (Grid[startPosition.X, startPosition.Y + i] == seaSymbol)
							Grid[startPosition.X, startPosition.Y + i] = boat.BoatSymbol;
						else
							errorMessage = "Impossible d'ajouter un bateau à cet emplacement car il est déjà occupé";
					break;
				case Direction.Gauche:
					for (int i = 0; i < boat.BoatSize; i++)
						if (Grid[startPosition.X - i, startPosition.Y] == seaSymbol)
							Grid[startPosition.X - i, startPosition.Y] = boat.BoatSymbol;
						else
							errorMessage = "Impossible d'ajouter un bateau à cet emplacement car il est déjà occupé";
					break;
				case Direction.Droite:
					for (int i = 0; i < boat.BoatSize; i++)
						if (Grid[startPosition.X + i, startPosition.Y] == seaSymbol)
							Grid[startPosition.X + i, startPosition.Y] = boat.BoatSymbol;
						else
							errorMessage = "Impossible d'ajouter un bateau à cet emplacement car il est déjà occupé";
					break;
				default:
					break;
			}


			Boats.Add(boat);

			if (errorMessage != string.Empty)
				return false;
			else
				return true;
		}

		public bool CheckGridLimits(Boat boat, Vector2Int startPosition, Direction direction)
		{
			switch (direction)
			{
				case Direction.Haut:
					if (startPosition.Y - (boat.BoatSize - 1) < 0)
						return true;
					else
						return false;
				case Direction.Bas:
					if (startPosition.Y + (boat.BoatSize - 1) >= Grid.GetLength(1))
						return true;
					else
						return false;
				case Direction.Gauche:
					if (startPosition.X + (boat.BoatSize - 1) < 0)
						return true;
					else
						return false;
				case Direction.Droite:
					if (startPosition.X + (boat.BoatSize - 1) >= Grid.GetLength(0))
						return true;
					else
						return false;
				default:
					return false;
			}
		}

		public void DisplayGrid()
		{
			for (int x = 0; x < Grid.GetLength(0); x++)
			{
				for (int y = 0; y < Grid.GetLength(1); y++)
				{
					Console.SetCursorPosition(x, y);
					Console.WriteLine(Grid[x, y]);
				}
			}
		}

		public void LoopBoard(Action<int, int> action)
		{
			for (int x = 0; x < Grid.GetLength(0); x++)
				for (int y = 0; y < Grid.GetLength(1); y++)
					action?.Invoke(x, y);
		}

		public bool CheckVictory(Board ennemyBoard)
		{
			bool isWin = true;

			foreach (char symbol in ennemyBoard.Grid)
				if (symbol != seaSymbol && symbol != deathSymbol)
					isWin = false;
			
			return isWin;
		}
	}
}
