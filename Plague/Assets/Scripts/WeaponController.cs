using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider2D;

    float colliderX;
    float colliderY;
    
    void Start()
    {
        animator      = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        colliderX     = boxCollider2D.offset.x;
        colliderY     = boxCollider2D.offset.y;
    }

    void Update()
    {
        animator.SetBool("Attack", Input.GetButtonDown("Attack"));
        if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "No Weapon")
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            if(horizontalMovement > 0f)
            {
                boxCollider2D.offset = new Vector2(colliderX, colliderY);
            }
            else if(horizontalMovement < 0f)
            {
                boxCollider2D.offset = new Vector2(-colliderX, colliderY);
            }
        }
    }
}
