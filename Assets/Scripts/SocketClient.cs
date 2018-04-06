/* Reference:
 * https://www.reddit.com/r/Unity3D/comments/4kr7vr/load_scene_without_switching/?st=j80q67bm&sh=b56e96e7
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using BestHTTP;
using BestHTTP.SocketIO;
using BestHTTP.SocketIO.Transports;


public class SocketClient : MonoBehaviour {

	private SocketManager manager;
	public Socket namespaceSocket;
    //public DataController dataController;


	// Use this for initialization
	void Start () {
		Debug.Log ("DataController start");
		InitSocket ();
		DontDestroyOnLoad (gameObject);
	}

	void OnDestroy(){
		
	}

	public void InitSocket(){
		SocketOptions options = new SocketOptions();
		options.AutoConnect = false;
		//options.ConnectWith = TransportTypes.WebSocket;

		manager = new SocketManager(new Uri(Constants.SOCKET_URI), options);
		Debug.Log (Constants.SOCKET_URI);
        namespaceSocket = manager.GetSocket("/pong");
		manager.Encoder = new BestHTTP.SocketIO.JsonEncoders.LitJsonEncoder();

		namespaceSocket.On(Constants.UPDATE, OnUpdate, true);
        //namespaceSocket.On(SocketIOEventTypes.Error, OnError);

		manager.Open();
	}

    private void ParseUpdateData(string dataAsJson){
        DataController.Instance.Data = JsonUtility.FromJson<GameData>(dataAsJson);
	}

	private void OnUpdate(Socket socket, Packet packet, params object[] args)
	{
        Debug.Log("OnUpdate");
		//ParseUpdateData(packet.RemoveEventName(true));
	}

	public void Quit(){
		if (namespaceSocket != null) { 
			namespaceSocket.On(Constants.UPDATE, OnUpdate);
		}
		if (manager != null) {
			manager.Close ();
		}
	}


	private void OnGetServerInfo(Socket socket, Packet packet, params object[] args){
		//		Debug.Log ("OnGetServerInfo");
		//Get Game client info and populate
	}

	//	private void OnGetLeaderboardCallback(Socket socket, Packet packet, params object[] args){
	//		string responseJSONString = "{\"leaderboard\":" + removeArrayWrapper(packet.Payload) + "}";
	//
	//		Debug.Log ("OnGetLeaderboardCallback " + responseJSONString);
	//		GameData responseData = JsonUtility.FromJson<GameData> (responseJSONString);
	//		GameData.leaderboard = responseData.leaderboard;
	//
	//		EventManager.TriggerEvent(Constants.UPDATED_LEADERBOARD_EVENT);
	//	}

	
//	private void OnError(Socket socket, Packet packet, params object[] args)
//	{
//		ServerResponse responseData = JsonUtility.FromJson<ServerResponse> (removeArrayWrapper(packet.Payload));
//
//		if (responseData.error == Constants.PROFANITY_ERROR) {
//			EventManager.TriggerEvent (Constants.SCORE_SUBMIT_ERROR_EVENT);
//		} else {
//			Debug.LogError ("SERVER ERROR");
//		}
//	}


}
