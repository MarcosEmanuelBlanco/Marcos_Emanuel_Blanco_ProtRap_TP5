using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrimerCambioInstrucciones : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoInstrucciones;
    [SerializeField] private GameObject llegada;

    void Update()
    {
        DesactivarTexto();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textoInstrucciones.text = "Atacá con ESPACIO";
        }
    }

    void DesactivarTexto()
    {
        if (!llegada.activeInHierarchy)
        {
            textoInstrucciones.gameObject.SetActive(false);
        }
    }
}
