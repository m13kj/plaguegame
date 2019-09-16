using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform player;
    public Transform camera;


    void Update()
    {
        camera.transform.position = new Vector3(player.position.x, player.position.y, camera.position.z);
    }
}
