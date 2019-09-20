using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;

    [Header ("Armor Status")]
    public float helmetStatus;
    public float chestStatus;
    public float legsStatus;
    public float armsStatus;

    private bool onePunchForDeath;
    private bool isDeath;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        onePunchForDeath = (helmetStatus * chestStatus * armsStatus * legsStatus > 0)? false : true;
        if(isDeath)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            if(onePunchForDeath) isDeath = true;
            float power     = col.gameObject.GetComponent<EnemyCommon>().power;
            int randomArmor = Random.Range(0, 4);
            switch(randomArmor)
            {
                case 0:
                    helmetStatus -= power;
                    break;
                case 1:
                    chestStatus  -= power;
                    break;
                case 2:
                    legsStatus   -= power;
                    break;
                case 3:
                    armsStatus   -= power;
                    break;
            } 
        }
    }

    void Movement()
    {
        Vector2 currentPos    = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput   = Input.GetAxis("Vertical");
        Vector2 inputVector   = new Vector2(horizontalInput, verticalInput);
        inputVector           = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement      = inputVector * movementSpeed;
        Vector2 newPos        = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
    }
}
