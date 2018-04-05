using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameScoreController : MonoBehaviour {

    public GameObject nameObject;
    public GameObject scoreObject;
	// Use this for initialization
	void Start () {
        DataController.Instance.onDataUpdate += SetScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetScore(){
        TextMesh nameTextMesh = nameObject.GetComponent<TextMesh>();
        TextMesh scoreTextMesh = scoreObject.GetComponent<TextMesh>();

        nameTextMesh.text = DataController.Instance.Data.game.redTeam.teamName;
        scoreTextMesh.text = DataController.Instance.Data.game.redTeam.Score.ToString();
    }

	private void OnDisable()
    {
        DataController.Instance.onDataUpdate -= SetScore;
	}
}
