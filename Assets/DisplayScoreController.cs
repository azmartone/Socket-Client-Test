using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScoreController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        DataController.Instance.onDataUpdate += SetScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetScore(){
        gameObject.GetComponent<TextMesh>().text = DataController.Instance.Data.game.redTeam.Score.ToString();
    }

	private void OnDisable()
    {
        DataController.Instance.onDataUpdate -= SetScore;
	}
}
