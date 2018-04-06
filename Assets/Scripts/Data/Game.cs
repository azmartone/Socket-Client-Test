using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Game{
    public Team redTeam;
    public Team blueTeam;

    public Team GetTeamByName(string name)
    {
        switch(name) {
            case "redTeam": return redTeam;
            case "blueTeam": return blueTeam;
            default: return null;
        }
    }
}
