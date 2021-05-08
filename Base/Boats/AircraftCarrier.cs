using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale.Base.Boats
{
	public abstract class AircraftCarrier : Boat
	{
		protected AircraftCarrier(int size = 5, char symbol = 'A') : base(size, symbol)
		{

		}
	}
}
