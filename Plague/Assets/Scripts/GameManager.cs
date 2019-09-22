using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public UIManager  uiManager;


    PlayerController playerController;

    void Awake()
    {
        player = Instantiate(player, player.transform.position, Quaternion.identity);
        playerController = player.GetComponent<PlayerController>();
    }

    void Start()
    {
        uiManager.SetPlayer(ref player);
    }

    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Enemy"))
        {
            Instantiate(enemy, enemy.transform.position, Quaternion.identity);
        }
    }
}
