using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrades : MonoBehaviour
{
    public void ExtendMag ()
    {
        PointSystem.totalPoints -= 1000;
        PointSystem.hasExtendedMag = 1;
    }
}
