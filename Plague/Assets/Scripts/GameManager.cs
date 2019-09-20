﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;

    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Enemy"))
        {
            Instantiate(enemy, enemy.transform.position, Quaternion.identity);
        }
    }
}
