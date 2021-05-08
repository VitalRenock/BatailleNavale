using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale.Base.Boats
{
	public abstract class Cruiser : Boat
	{
		protected Cruiser(int size = 4, char symbol = 'C') : base(size, symbol)
		{

		}
	}
}
