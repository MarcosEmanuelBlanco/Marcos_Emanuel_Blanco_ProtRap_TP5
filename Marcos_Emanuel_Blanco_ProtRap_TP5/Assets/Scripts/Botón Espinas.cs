using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotónEspinas : MonoBehaviour
{
    [SerializeField] private GameObject espinas;

    private void Start()
    {
        espinas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(nameof(ActivarEspinas));
        }
    }
    private IEnumerator ActivarEspinas()
    {
        espinas.SetActive(true);
        yield return new WaitForSeconds(1);
        espinas.SetActive(false);
    }
}
