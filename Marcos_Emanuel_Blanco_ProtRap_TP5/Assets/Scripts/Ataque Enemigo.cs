using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    [SerializeField] private Transform representacionAtaqueEnemigo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(nameof(ActivarAtaqueEnemigo));
            collision.transform.GetComponent<Jugador>().ActivarFantasma();
            collision.transform.GetComponent<Jugador>().SumarMuertes();
        }
    }

    private IEnumerator ActivarAtaqueEnemigo()
    {
        representacionAtaqueEnemigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        representacionAtaqueEnemigo.gameObject.SetActive(false);
    }
}
