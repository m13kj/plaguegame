using System;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    float helmetStatus;
    float chestStatus;
    float legsStatus;
    float armsStatus;

    public SaveData(PlayerController player)
    {
        this.helmetStatus = player.helmetStatus;
        this.chestStatus  = player.chestStatus;
        this.legsStatus   = player.legsStatus;
        this.armsStatus   = player.armsStatus;
    }
}
