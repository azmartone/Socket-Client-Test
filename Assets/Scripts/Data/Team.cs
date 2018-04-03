using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Team {
	public string id; //red or blue

    [SerializeField]
	private int score;

 //   [SerializeField]
	//private int _prevScore;
    public string teamName;

    //public int score;
    public int prevScore;


	public int Score
	{
		get{
			return score;
		}
		set{
            score = value;
            Debug.Log("I just set _score to" + value);
		}
	}

	//public int prevScore
	//{
	//	get{
	//		return _prevScore;
	//	}
	//	set{
 //           _prevScore = value;
 //           //Debug.Log("I just set _prevScore to" + value);
	//	}
	//}
}
