using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegundaPuerta : MonoBehaviour
{
    [SerializeField] private GameObject guardia;

    private void AbrirSegundaPuerta()
    {
        if (!guardia.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        AbrirSegundaPuerta();
    }
}
