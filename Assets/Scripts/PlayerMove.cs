using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5;
    public float rotationSpeed = 10; // Rotasyon hýzý
    public Animator animator; // Animator bileþeni

    // Update is called once per frame
    void Update()
    {
        MoveAndAnimate();
    }

    void MoveAndAnimate()
    {
        bool isMoving = false; // Karakter hareket ediyor mu?

        // Hareket kontrolü
        if (Input.GetKey(KeyCode.W)) // ileri
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            RotateCharacter(Vector3.forward);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A)) // sola
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            RotateCharacter(Vector3.left);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S)) // geri
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            RotateCharacter(Vector3.back);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D)) // saða
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            RotateCharacter(Vector3.right);
            isMoving = true;
        }

        // Animasyonu güncelle
        if (animator != null)
        {
            animator.SetFloat("Speed", isMoving ? 1f : 0f); // "Speed" parametresi Idle (0) veya Walk (1)
        }
    }

    // Karakteri hareket ettiði yöne döndür
    void RotateCharacter(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction); // Hedef rotasyon
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}


        
