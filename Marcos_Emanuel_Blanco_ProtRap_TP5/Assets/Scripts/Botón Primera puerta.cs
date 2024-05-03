using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotónPrimerapuerta : MonoBehaviour
{
    [SerializeField] private GameObject primeraPuerta;

    private void AbrirPuerta()
    {
        primeraPuerta.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AbrirPuerta();
        }
    }
}
