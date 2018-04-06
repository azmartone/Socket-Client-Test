using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameScoreController : MonoBehaviour {

    public GameObject nameObject;
    public GameObject scoreObject;
    public enum TeamColor { redTeam, blueTeam }
    public TeamColor teamColor;
	// Use this for initialization
	void Start () {
        SetScore();
        DataController.Instance.onDataUpdate += SetScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetScore(){
        TextMesh nameTextMesh = nameObject.GetComponent<TextMesh>();
        TextMesh scoreTextMesh = scoreObject.GetComponent<TextMesh>();

        if (DataController.Instance.Data != null){
            
            Team team = DataController.Instance.Data.game.GetTeamByName(teamColor.ToString());
            nameTextMesh.text = team.teamName;
            scoreTextMesh.text = team.Score.ToString();
        } else {
            nameTextMesh.text = "Waiting for Score";
            scoreTextMesh.text = "---";
        }
        Debug.Log(nameTextMesh.text + " " + scoreTextMesh.text);
    }

	private void OnDisable()
    {
        DataController.Instance.onDataUpdate -= SetScore;
	}
}
