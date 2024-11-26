using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimintosPlayer2 : MonoBehaviour
{
    public EstadoDePlayer2 estados;
    public DetectorDeColisiones detectorIzquierdoPalo5; // Detector para el lado izquierdo del palo 1
    public DetectorDeColisiones detectorDerechoPalo5;  // Detector para el lado derecho del palo 1

    public DetectorDeColisiones detectorIzquierdoPalo8; // Detector para el lado izquierdo del palo 4
    public DetectorDeColisiones detectorDerechoPalo8;  // Detector para el lado derecho del palo 4

    public GameObject palo5; // Referencia al objeto del palo 1
    public GameObject palo8; // Referencia al objeto del palo 4

    public float velocidad = 30f; // Velocidad de movimiento
    public float velocidadRotacion = 500f; // Velocidad de rotación



    void Update()
    {
        if (estados.palo5)
        {
            Mover(palo5, detectorIzquierdoPalo5, detectorDerechoPalo5);
        }
        else if (estados.palo8)
        {
            Mover(palo8, detectorIzquierdoPalo8, detectorDerechoPalo8);
        }
    }

    void Mover(GameObject palo, DetectorDeColisiones detectorIzquierdo, DetectorDeColisiones detectorDerecho)
    {
        // Movimiento horizontal
        float movimiento = Input.GetAxis("HorizontalPlayer2");

        // Rotación
        float rotacion = Input.GetAxis("VerticalPlayer2"); // Usa el eje Vertical para controlar la rotación

        // Permitir el movimiento hacia la derecha si no está colisionando con el muro derecho
        if (movimiento > 0 && !detectorDerecho.estaColisionando)
        {
            palo.transform.Translate(Vector3.forward * velocidad * Time.deltaTime * movimiento);
        }
        // Permitir el movimiento hacia la izquierda si no está colisionando con el muro izquierdo
        else if (movimiento < 0 && !detectorIzquierdo.estaColisionando)
        {
            palo.transform.Translate(Vector3.forward * velocidad * Time.deltaTime * movimiento);
        }
        else
        {
            //Debug.Log("Movimiento restringido debido a una colisión con un muro.");
        }

        // Aplicar rotación
        if (rotacion != 0)
        {
            palo.transform.Rotate(Vector3.forward, rotacion * velocidadRotacion * 2f * Time.deltaTime);
        }

    }
}
