using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale.Base.Boats
{
	public abstract class Boat
	{
		public int BoatSize { get; set; }
		public char BoatSymbol { get; set; }
		public int[,] BoatPosition { get; set; }

		protected Boat(int size, char symbol)
		{
			BoatSize = size;
			BoatSymbol = symbol;
		}
	}
}
