using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemigoInf"))
        {
            collision.transform.GetComponent<Enemigo>().DestruirEnemigo();
        }

        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<Jugador>().ActivarFantasma();
        }
    }
}
