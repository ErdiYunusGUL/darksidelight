using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveKillAnimals : MonoBehaviour
{

    public GameObject Panel; 

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player")) 
        {
            Panel.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Panel.SetActive(false); 
        }
    }

}
