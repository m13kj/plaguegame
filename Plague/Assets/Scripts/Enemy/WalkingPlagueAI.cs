using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPlagueAI : EnemyAI
{
    override protected void Action()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyCommon.speed * Time.deltaTime);
    }
}
