using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public int damage = 1;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            //enemyspace  enemy2 = other.GetComponent<enemyspace>();
            if (enemy != null )
            {
                enemy.TakeDamage(damage);
            }
            /*else if(enemy2 !=null)
            {
                enemy2.TakeDamage(damage);
            }*/
        }
    }
}
