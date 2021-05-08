using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Base.Boats;
using BatailleNavale.Base.Entity;
using BatailleNavale.Base.Factories;
using BatailleNavale.Red.Boats;
using BatailleNavale.Red.Entity;

namespace BatailleNavale.Red.Factories
{
	public class RedFactory : IFactory
	{
		#region Player Factory
		
		public Player CreatePlayer() => new RedPlayer();

		#endregion
		
		#region Boats Factories
		
		public AircraftCarrier CreateAircraftCarrier() => new RedAircraftCarrier();
		public Cruiser CreateCruiser() => new RedCruiser();
		public Destroyer CreateDestroyer() => new RedDestroyer();
		public SubMarine CreateSubMarine() => new RedSubMarine();
		public TorpedoBoat CreateTorpedoBoat() => new RedTorpedoBoat(); 

		#endregion
	}
}
