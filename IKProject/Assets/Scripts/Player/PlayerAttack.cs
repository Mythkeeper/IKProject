using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack; //So that player cannot spam attack
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask WhatIsEnemies;
    public float attackRange;
    public int damage;
    
    public Animator playerAnim;

   

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <=0){
            //then we can attack
            if(Input.GetKey(KeyCode.Mouse0)) // to get left click input
            {
                
                playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,WhatIsEnemies); // check for all enemies in a certain radius and deal dmg
                for (int i=0;i<enemiesToDamage.Length;i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            timeBtwAttack =startTimeBtwAttack;
        } else {
            timeBtwAttack-=Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}