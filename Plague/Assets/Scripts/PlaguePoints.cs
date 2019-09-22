using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaguePoints : MonoBehaviour
{
    int plaguePoints = 0;

    public void SetPlaguePoints(int plaguePoints) { this.plaguePoints = plaguePoints; }

    public int GetPlaguePoints() { return plaguePoints; }
}
