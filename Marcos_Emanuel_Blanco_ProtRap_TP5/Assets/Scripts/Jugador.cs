using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    private float direccionx = 0;
    private float direcciony = 0;
    public float muertes;
    public bool muerto;
    public bool volviendo;
    private SpriteRenderer spriteJugador;
    [SerializeField] private float duracionFantasma;
    [SerializeField] private Transform representacionAtaque;
    [SerializeField] private Transform posicionControladorGolpe;
    [SerializeField] private GameObject puntoReaparicion;
    [SerializeField] private float esperaSiguienteAtaque;
    [SerializeField] private float intervaloEntreGolpes;
    [SerializeField] private float radioGolpe;
    private Vector3 posReaparicion;
    [SerializeField] private TextMeshProUGUI textoCantidadMuertes;
    [SerializeField] private UnityEvent<string> OnTotalDeathsChange;
    private void Start()
    {
        muertes = 0;
        muerto = false;
        volviendo = false;
        spriteJugador = GetComponent<SpriteRenderer>();
        representacionAtaque.gameObject.SetActive(false);
        OnTotalDeathsChange.Invoke(muertes.ToString());
        textoCantidadMuertes.gameObject.SetActive(false);
    }
    private void Mover()
    {
        direccionx = Input.GetAxis("Horizontal");
        direcciony = Input.GetAxis("Vertical");
        Vector3 posicion = transform.position + new Vector3(0.2f * direccionx, 0.2f * direcciony, 0f);
        posReaparicion = posicion;
        transform.position = posicion;
        if(!muerto)
        {
            puntoReaparicion.transform.localPosition = posicion;
        }
    }
    void FixedUpdate()
    {
        Mover();
    }
    private void Ataque()
    {
        if(!muerto)
        {
            if(esperaSiguienteAtaque > 0)
            {
                esperaSiguienteAtaque -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                esperaSiguienteAtaque = intervaloEntreGolpes;
                Golpe();
                StartCoroutine(nameof(ActivarAtaque));
            }
        }
    }
    private IEnumerator ActivarAtaque()
    {
        representacionAtaque.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        representacionAtaque.gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(posicionControladorGolpe.position, radioGolpe);
    }
    private void Golpe()
    {
        Collider2D[] areaGolpe = Physics2D.OverlapCircleAll(posicionControladorGolpe.position, radioGolpe);
        foreach (Collider2D col in areaGolpe)
        {
            if (col.CompareTag("Enemigo"))
            {
                col.transform.GetComponent<Enemigo>().DestruirEnemigo();
            }
        }
    }
    private void Update()
    {
        VolverDeLaMuerte();
        Ataque();
    }
    public void ActivarFantasma()
    {
        StartCoroutine(nameof(Fantasma));
    }
    private void VolverDeLaMuerte()
    {
        if (volviendo && transform.position != puntoReaparicion.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoReaparicion.transform.position, 0.02f);
        }

        if (volviendo && transform.position == puntoReaparicion.transform.position)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Muro"), false);
            spriteJugador.color = Color.blue;
            muerto = false;
            volviendo = false;
        }
    }
    private IEnumerator Fantasma()
    {
        muerto = true;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Muro"), true);
        spriteJugador.color = Color.white;
        yield return new WaitForSeconds(duracionFantasma);
        volviendo = true;
    }
    public void SumarMuertes()
    {
        muertes += 0.25f;
        OnTotalDeathsChange.Invoke(muertes.ToString());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            textoCantidadMuertes.gameObject.SetActive(true);
            collision.transform.GetComponent<LLegada>().DetectarJugador();
        }
    }
}
