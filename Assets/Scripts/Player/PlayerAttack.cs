using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class PlayerAttack : PlayerStats
=======
public class PlayerAttack : CharacterStats
>>>>>>> a7a94dba4fb262a58d76dc93bbefb285fbd7bdec
{
    private float timeBtwAttack; //So that player cannot spam attack
    public float startTimeBtwAttack; //changable variable to smooth things out
    public Transform attackPos; //Object that detects enemies through enemies layer mask
    public LayerMask WhatIsEnemies; // enemies layer mask
    public float attackRange; //range
    
    public Animator playerAnim; // animator

   

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <=0){
            //then we can attack
            if(Input.GetKey(KeyCode.Mouse0)) // to get left click input
            {
<<<<<<< HEAD
                print(damage.GetValue());
                playerAnim.SetTrigger("attack");// trigger attack anim
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,WhatIsEnemies); // check for all enemies in a certain radius and deal dmg
                for (int i=0;i<enemiesToDamage.Length;i++){
                    enemiesToDamage[i].GetComponent<CharacterStats>().TakeDamage(damage.GetValue());
=======
                
                playerAnim.SetTrigger("attack");// trigger attack anim
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,WhatIsEnemies); // check for all enemies in a certain radius and deal dmg
                for (int i=0;i<enemiesToDamage.Length;i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage.GetValue());
>>>>>>> a7a94dba4fb262a58d76dc93bbefb285fbd7bdec
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