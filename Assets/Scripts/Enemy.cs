using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100; // Düþmanýn caný
    public float speed = 3f; // Düþmanýn hýzý
    public int damage = 10; // Oyuncuya verdiði hasar 
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
            Debug.Log("Aslan öldü!");
            Destroy(gameObject); // Aslaný sahneden kaldýr
            ShowMessage(); // Mesajý göster
        }
    }

    void ShowMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true); // Mesajý aktif et
            messageText.text = "Geyiði Kurtardýn sen çok önemli bir kiþiliksin.... ";
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
