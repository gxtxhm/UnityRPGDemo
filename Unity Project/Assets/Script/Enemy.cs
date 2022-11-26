using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    int curHp;
    Rigidbody rigid;
    Collider enemyCollider;
    bool isDamaged = false;
    void Start()
    {
        maxHp = 100;
        curHp = maxHp;
        rigid = GetComponent<Rigidbody>();
        enemyCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (!isDamaged&&other.tag=="Hammer")
        {
            //약간 뒤로 충격 + 1초정도 무적 코루틴으로
            Debug.Log("Hammer에 맞음!");
            curHp -= other.gameObject.GetComponentInParent<Weapon>().damage;
            StartCoroutine("Damaged");
        }
    }

    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(0.1f);
        isDamaged = true;
        yield return new WaitForSeconds(0.6f);
        isDamaged = false;

    }
}
