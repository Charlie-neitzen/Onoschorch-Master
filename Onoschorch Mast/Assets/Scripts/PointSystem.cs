using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public static int points;
    public TextMeshProUGUI pointboard;

    private void Update()
    {
        pointboard.text = $"{points} Points";
    }
}
