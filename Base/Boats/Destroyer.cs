using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale.Base.Boats
{
	public abstract class Destroyer : Boat
	{
		protected Destroyer(int size = 3, char symbol = 'D') : base(size, symbol)
		{

		}
	}
}
