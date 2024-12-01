using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
   public GameObject knifePrefab;

    public Transform throwPoint;

    public float throwForce;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ThrowKnife();
        }
    }


    void ThrowKnife()
    {
        GameObject knife = Instantiate(knifePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = knife.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward* throwForce * -1 , ForceMode.Impulse);
        Destroy( knife ,3F );
            
    }

}
