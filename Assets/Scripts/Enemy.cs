using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100; // Düþmanýn caný
    public float speed = 3f; // Düþmanýn hýzý
    public int damage = 10; // Oyuncuya verdiði hasar 
    public Transform player;


    // Update is called once per frame
    void Update()
    {
        if (player !=null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player);
        }
    }

    public void TakeDAmage( int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }

        void Die()
        {
            // ölüm animasyonu eklenecek 
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
