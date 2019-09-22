using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public Text plaguePoints;
    public Text helmetStatus;
    public Text chestStatus;
    public Text legsStatus;
    public Text armsStatus;

    [Header("Camera")]
    public Transform playerCamera;
    

    Transform        playerPosition;
    PlayerController playerController; 
    
    void Update()
    {
        playerCamera.transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y, playerCamera.position.z);
        plaguePoints.text = playerController.GetPlaguePoints().ToString();
        helmetStatus.text = playerController.helmetStatus.ToString();
        chestStatus.text  = playerController.chestStatus.ToString();
        legsStatus.text   = playerController.legsStatus.ToString();
        armsStatus.text   = playerController.armsStatus.ToString();
    }

    public void SetPlayer(ref GameObject player)
    {
        this.playerPosition   = player.transform;
        this.playerController = player.GetComponent<PlayerController>();
    }
}
