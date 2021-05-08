using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatailleNavale.Base.Boats;
using BatailleNavale.Base.Entity;
using BatailleNavale.Base.Factories;
using BatailleNavale.Blue.Boats;
using BatailleNavale.Blue.Entity;

namespace BatailleNavale.Blue.Factories
{
	public class BlueFactory : IFactory
	{
		#region Player Factory

		public Player CreatePlayer() => new BluePlayer();

		#endregion

		#region Boats Factories
		
		public AircraftCarrier CreateAircraftCarrier() => new BlueAircraftCarrier();
		public Cruiser CreateCruiser() => new BlueCruiser();
		public Destroyer CreateDestroyer() => new BlueDestroyer();
		public SubMarine CreateSubMarine() => new BlueSubMarine();
		public TorpedoBoat CreateTorpedoBoat() => new BlueTorpedoBoat(); 

		#endregion
	}
}
