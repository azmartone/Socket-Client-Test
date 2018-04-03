/* 
 * This is a singleton manager for the data https://www.youtube.com/watch?v=EI1KJv8owCg
 */

using System;
using System.Collections;
using UnityEngine;

public class DataController : MonoBehaviour
{

    public delegate void handleDataUpdate();
    public event handleDataUpdate onDataUpdate;

    private static DataController _instance;
    public static DataController Instance {
        get{
            if(_instance == null){
                GameObject go = new GameObject("DataController");
                go.AddComponent<DataController>();
            }
            return _instance;
        }
    }

    private GameData data;
    public GameData Data {
        get
        {
            return data;
        }
        set
        {
            data = value;
            onDataUpdate();
        }
    
    }

	private void Awake()
	{
        _instance = this;
	}

	void Start()
    {
        
    }

    void OnDestroy()
    {

    }
}
