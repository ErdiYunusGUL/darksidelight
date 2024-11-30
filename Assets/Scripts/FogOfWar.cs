using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    public Material fogMaterial; // Shader'a sahip materyal
    public Transform player; // Karakter
    public float revealRadius = 5.0f; // A���a ��kan alan�n yar��ap�

    void Update()
    {
        // Karakterin pozisyonunu Shader'a g�nder
        fogMaterial.SetVector("_PlayerPosition", new Vector4(player.position.x-1, player.position.y, player.position.z, 1));
        fogMaterial.SetFloat("_RevealRadius", revealRadius);
    }
}
