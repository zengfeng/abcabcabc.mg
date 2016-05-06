using UnityEngine;
using System.Collections;

namespace CC.Runtime
{
	public class Service : IService
	{
		private PacketManager _packetManager;
		public PacketManager packetManager
		{
			get
			{
				if(_packetManager == null)
					_packetManager = Coo.packetManager;
				return _packetManager;
			}

			set
			{
				_packetManager = value;
			}
		}

	}
}
