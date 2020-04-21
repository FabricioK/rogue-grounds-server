using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class RoomAvailable
{
	public uint clients;
	public uint maxClients;
	public string name;
	public string roomId;
	public string processId;
	// public object metadata;
}