using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100; // D��man�n can�
    public float speed = 3f; // D��man�n h�z�
    public int damage = 10; // Oyuncuya verdi�i hasar 
    public Text messageText;
    public Transform player;

    private void Start()
    {
        messageText.gameObject.SetActive(false);
    }
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
   
    public void TakeDamage( int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }

        void Die()
        {
            Debug.Log("Aslan �ld�!");
            Destroy(gameObject); // Aslan� sahneden kald�r
            ShowMessage(); // Mesaj� g�ster
        }
    }

    void ShowMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true); // Mesaj� aktif et
            messageText.text = "Geyi�i Kurtard�n sen �ok �nemli bir ki�iliksin.... ";
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
