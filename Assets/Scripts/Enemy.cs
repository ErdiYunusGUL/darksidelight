using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100; // D��man�n can�
    public float speed = 3f; // D��man�n h�z�
    public int damage = 10; // Oyuncuya verdi�i hasar 
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
            // �l�m animasyonu eklenecek 
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
