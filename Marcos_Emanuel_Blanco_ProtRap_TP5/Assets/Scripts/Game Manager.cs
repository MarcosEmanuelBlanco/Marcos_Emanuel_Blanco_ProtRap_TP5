using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> OnTotalTimeChange;
    [SerializeField] private TextMeshProUGUI textoTiempoFinal;
    [SerializeField] private TextMeshProUGUI textoNivelCompletado;
    private float tiempo = 0;
    private bool reinicio;
    [SerializeField] private GameObject llegada;

    void Start()
    {
        tiempo = 0;
        OnTotalTimeChange.Invoke(tiempo.ToString());
        textoNivelCompletado.gameObject.SetActive(false);
        textoTiempoFinal.gameObject.SetActive(false);
        reinicio = false;
    }


    void Update()
    {
        RestarTiempo();
        ReiniciarEscena();
        SiguienteNivel();
        NivelCompletado();
        CerrarApp();
    }

    void RestarTiempo()
    {
        tiempo += Time.deltaTime;
        Mathf.RoundToInt(tiempo);
        OnTotalTimeChange.Invoke(tiempo.ToString());
    }

    void NivelCompletado()
    {
        if (!llegada.activeInHierarchy)
        {
            Time.timeScale = 0;
            textoNivelCompletado.gameObject.SetActive(true);
            textoTiempoFinal.gameObject.SetActive(true);
            reinicio = true;
        }
    }
    void ReiniciarEscena()
    {
        if (reinicio && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            reinicio = false;
            llegada.SetActive(true);
        }
    }

    void SiguienteNivel()
    {
        if (reinicio && Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            reinicio = false;
            llegada.SetActive(true);
        }
    }

    void CerrarApp()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
