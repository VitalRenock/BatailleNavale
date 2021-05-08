using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale.Base.Boats
{
	public abstract class TorpedoBoat : Boat
	{
		protected TorpedoBoat(int size = 2, char symbol = 'T') : base(size, symbol)
		{

		}
	}
}
