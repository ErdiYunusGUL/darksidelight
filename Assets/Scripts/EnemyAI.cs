using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Oyuncunun pozisyonu
    private NavMeshAgent agent; // NavMeshAgent bile�eni

    // Start is called before the first frame update
    void Start()
    {
        // NavMeshAgent bile�enini al
        agent = GetComponent<NavMeshAgent>();

        if (player == null && GameObject.FindWithTag("Player") != null)
        {
            // Oyuncuyu otomatik olarak "Player" tag'ine g�re bul
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Oyuncunun pozisyonuna do�ru hareket et
            agent.SetDestination(player.position);
        }
    }
}
