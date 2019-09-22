using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    [Header("Main")]
    public int   hp;
    public int   power;
    public float speed;

    [Header("Plague Points")]
    public PlaguePoints plaguePoints;
    public int          minPlaguePoints;
    public int          maxPlaguePoints;
}
