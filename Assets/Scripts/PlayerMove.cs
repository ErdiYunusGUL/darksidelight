using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f; 
    public float rotationSpeed = 10f;
    public Transform cameraTransform;
    Animator animator;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) 
        { 
         // Kameranýn yönüne göre karakterin bakýþ yönünü hesapla
         float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            
        // Akýcý dönüþ için karakterin rotasyonunu interpolasyonla deðiþtir
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Karakteri ileri hareket ettir
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        rb.MovePosition(transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        UpdateAnimation(vertical);




    }
    
    void UpdateAnimation(float vertical)
    {
        // Animator'daki Speed parametresini ayarla
        if (vertical > 0)
        {
            animator.SetFloat("Speed", 1f); // Ýleri animasyonu
        }
        else if (vertical < 0)
        {
            animator.SetFloat("Speed", -1f); // Geri animasyonu
        }
        else
        {
            animator.SetFloat("Speed", 0f); // Idle animasyonu
        }
    }


}
