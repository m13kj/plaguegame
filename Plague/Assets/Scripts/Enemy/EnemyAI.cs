using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }

    protected abstract void Action();
}
