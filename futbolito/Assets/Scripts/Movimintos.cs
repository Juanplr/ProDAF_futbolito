using UnityEngine;

public class Movimintos : MonoBehaviour
{
    public EstadosDeTablero estados;
    public DetectorDeColisiones detectorIzquierdoPalo1; // Detector para el lado izquierdo del palo 1
    public DetectorDeColisiones detectorDerechoPalo1;  // Detector para el lado derecho del palo 1

    public DetectorDeColisiones detectorIzquierdoPalo4; // Detector para el lado izquierdo del palo 4
    public DetectorDeColisiones detectorDerechoPalo4;  // Detector para el lado derecho del palo 4

    public GameObject palo1; // Referencia al objeto del palo 1
    public GameObject palo4; // Referencia al objeto del palo 4

    public float velocidad = 30f; // Velocidad de movimiento
    public float velocidadRotacion = 500f; // Velocidad de rotación



    void Update()
    {
        if (estados.palo1)
        {
            Mover(palo1, detectorIzquierdoPalo1, detectorDerechoPalo1);
        }
        else if (estados.palo4)
        {
            Mover(palo4, detectorIzquierdoPalo4, detectorDerechoPalo4);
        }
    }

    void Mover(GameObject palo, DetectorDeColisiones detectorIzquierdo, DetectorDeColisiones detectorDerecho)
    {
        // Movimiento horizontal
        float movimiento = Input.GetAxis("Horizontal");

        // Rotación
        float rotacion = Input.GetAxis("Vertical"); // Usa el eje Vertical para controlar la rotación

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
