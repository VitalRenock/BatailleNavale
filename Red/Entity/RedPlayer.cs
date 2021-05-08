using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Base.Boats;
using BatailleNavale.Base.Entity;
using BatailleNavale.Red.Boats;

namespace BatailleNavale.Red.Entity
{
	public class RedPlayer : Player
	{
		public RedPlayer()
		{
			Color = ConsoleColor.Red;
		}
	}
}
