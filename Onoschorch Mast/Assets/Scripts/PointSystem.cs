using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public static int totalPoints;
    public static int points;
    public TextMeshProUGUI pointboard;

    public void Start()
    {
        LoadPlayer();
    }
    public void Update()
    {
        SavePlayer();
        pointboard.text = $"{points} Points";
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        totalPoints = data.totalPoints;
    }
}
