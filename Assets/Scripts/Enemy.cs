using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int health;
    public float speed;
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if(health <=0){
            Destroy(gameObject);
        }
        if(Vector2.Distance(transform.position, target.position)>3)
        transform.position=Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);//time.detlta time is used to ignore pc performace
    }

    public void TakeDamage(int damage){
        
        health-=damage;
        
    }
}