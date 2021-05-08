using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale.Base.Boats
{
	public abstract class SubMarine : Boat
	{
		protected SubMarine(int size = 3, char symbol = 'S') : base(size, symbol)
		{

		}
	}
}
