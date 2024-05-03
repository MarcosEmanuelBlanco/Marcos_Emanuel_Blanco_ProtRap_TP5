using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform representacionAtaqueEnemigo;

    private void Start()
    {
        representacionAtaqueEnemigo.gameObject.SetActive(false);
    }
    public void DestruirEnemigo()
    {
        gameObject.SetActive(false);
    }
}
