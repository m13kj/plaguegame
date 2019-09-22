using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

abstract public class EnemyAI : MonoBehaviour
{
    protected GameObject player;
    protected EnemyCommon enemyCommon;

    void Start()
    {
        player      = GameObject.FindGameObjectWithTag("Player");
        enemyCommon = GetComponent<EnemyCommon>();
    }

    void Update()
    {
        if(player.activeInHierarchy)
            Action();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Weapon"))
        {
            WeaponHit();
        }
    }

    virtual protected void WeaponHit()
    {
        if(--enemyCommon.hp <= 0)
            {
                int randomPlaguePoints = Random.Range(enemyCommon.minPlaguePoints, enemyCommon.maxPlaguePoints);
                enemyCommon.plaguePoints = Instantiate(enemyCommon.plaguePoints.gameObject, transform.position, Quaternion.identity).GetComponent<PlaguePoints>();
                enemyCommon.plaguePoints.SetPlaguePoints(randomPlaguePoints);
                Destroy(gameObject);
            }
    }
    protected abstract void Action();
}
