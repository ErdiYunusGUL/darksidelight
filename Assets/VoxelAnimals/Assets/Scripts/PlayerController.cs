using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1, jump = 50;
    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.Translate(movement * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.W))//forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))//left
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))//back
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))//right
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
