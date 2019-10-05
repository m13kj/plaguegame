using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;

    [Header ("Armor Status")]
    public int helmetStatus;
    public int chestStatus;
    public int legsStatus;
    public int armsStatus;

    private int   maxArmorStatus = 100;
    private int   plaguePoints   = 0;
    private bool  onePunchForDeath;
    private bool  isDeath;

    private float horizontalInput;
    private float verticalInput;
    private bool  back;

    Rigidbody2D rbody;
    Animator    animator;

    private void Awake()
    {
        rbody    = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput   = Input.GetAxis("Vertical");
        if(verticalInput > 0f) back = true;
        else if(verticalInput < 0f) back = false; 
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalInput));
        animator.SetBool("Back", back);
        onePunchForDeath = (helmetStatus * chestStatus * armsStatus * legsStatus > 0)? false : true;
        if(isDeath)
        {
            gameObject.SetActive(false);
        }
        RepairArmor();
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
            int power       = col.gameObject.GetComponent<EnemyCommon>().power;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Plague Point"))
        {
            plaguePoints += col.gameObject.GetComponent<PlaguePoints>().GetPlaguePoints();
            Destroy(col.gameObject);
        }
    }

    public int GetPlaguePoints()
    {
        return plaguePoints;
    }

    void RepairArmor()
    {
        if(Input.GetButtonDown("Helmet Repair"))
        {
            RepairArmorPart(ref helmetStatus);
        }
        else if(Input.GetButtonDown("Chest Repair"))
        {
            RepairArmorPart(ref chestStatus);
        }
        else if(Input.GetButtonDown("Legs Repair"))
        {
            RepairArmorPart(ref legsStatus);
        }
        else if(Input.GetButtonDown("Arms Repair"))
        {
            RepairArmorPart(ref armsStatus);
        }
    }

    void RepairArmorPart(ref int armorPart)
    {
        int toRepair = maxArmorStatus - armorPart;
        if(plaguePoints - toRepair > 0)
        {
            plaguePoints -= toRepair;
            armorPart    += toRepair;
        }
        else
        {
            armorPart   += plaguePoints;
            plaguePoints = 0;
        }
    }

    void Movement()
    {
        Vector2 currentPos    = rbody.position;
        Vector2 inputVector   = new Vector2(horizontalInput, verticalInput);
        inputVector           = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement      = inputVector * movementSpeed;
        Vector2 newPos        = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
    }
}
