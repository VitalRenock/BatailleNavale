using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Base.Boats;
using BatailleNavale.Game;

namespace BatailleNavale.Base.Entity
{
	public abstract class Player
	{
		// Properties
		public ConsoleColor Color { get; set; }
		public Board Board { get; set; }

		// Constructor
		public Player()
		{
			Board = new Board(10, 10);
		}
	}
}
