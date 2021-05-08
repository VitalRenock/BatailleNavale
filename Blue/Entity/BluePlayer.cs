using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Base.Boats;
using BatailleNavale.Base.Entity;
using BatailleNavale.Blue.Boats;

namespace BatailleNavale.Blue.Entity
{
	public class BluePlayer : Player
	{
		public BluePlayer()
		{
			Color = ConsoleColor.Cyan;
		}
	}
}
