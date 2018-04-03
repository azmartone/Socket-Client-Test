using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
//	public const string SERVER_ADDRESS = "http://pong.wildlife.la";
		public const string SERVER_ADDRESS = "http://localhost:3000";
	public const string SOCKET_URI = SERVER_ADDRESS + "/socket.io/";
	public const string HARDWARE_STATE_CHANGE = "hardwareStateChange";
	public const string UPDATE = "update";
}
