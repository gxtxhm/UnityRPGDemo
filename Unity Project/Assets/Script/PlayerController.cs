using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHp;
    int curHp;

    Rigidbody playerRigid;
    Animator animator;

    public float speed = 3f;
    float horizontal, vertical;
    Vector3 moveVec;

    Weapon weapon;
    public float swingDelay = 0.5f;
    float lastSwing;
    void Start()
    {
        maxHp = 100;
        curHp = maxHp;
        playerRigid = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        // 나중에 바꿔야함
        weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    
    void PlayerMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveVec = new Vector3(horizontal, 0, vertical).normalized;
        transform.LookAt(transform.position + moveVec);
        if((horizontal!=0||vertical!=0)&&Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("IsRun", true);
            transform.position += moveVec *2* speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("IsRun", false);
            transform.position += moveVec * speed * Time.deltaTime;
        }

        
        if(horizontal!=0||vertical!=0)
        {
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            

            // 
            if(swingDelay+lastSwing<Time.time)
            {
                Debug.Log("공격!");
                animator.SetTrigger("IsAttack");
                weapon.UseWeapon();
                lastSwing = Time.time;
            }

            
        }
    }

}
