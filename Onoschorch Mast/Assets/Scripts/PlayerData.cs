using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public int totalPoints;
    public int hasExtendedMag;

    public PlayerData (PointSystem point)
    {
        totalPoints = PointSystem.totalPoints;
        hasExtendedMag = PointSystem.hasExtendedMag;
    }

}
