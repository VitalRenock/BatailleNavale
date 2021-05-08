using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Base.Boats;
using BatailleNavale.Base.Entity;

namespace BatailleNavale.Base.Factories
{
	public interface IFactory
	{
		Player CreatePlayer(); 

		AircraftCarrier CreateAircraftCarrier();
		Cruiser CreateCruiser();
		Destroyer CreateDestroyer();
		SubMarine CreateSubMarine();
		TorpedoBoat CreateTorpedoBoat();
	}
}