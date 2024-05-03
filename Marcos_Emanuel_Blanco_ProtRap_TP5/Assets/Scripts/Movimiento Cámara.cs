using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCámara : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 desviacion = new(0f, 0f, -10f);

    void LateUpdate()
    {
        if (objetivo != null)
        {
            transform.position = objetivo.position + desviacion;
            transform.LookAt(objetivo.position);
        }
    }
}
