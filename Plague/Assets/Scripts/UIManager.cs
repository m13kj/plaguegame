using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform player;
    public Transform playerCamera;


    void Update()
    {
        playerCamera.transform.position = new Vector3(player.position.x, player.position.y, playerCamera.position.z);
    }
}
