using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosManoI : MonoBehaviour
{
    public EstadosDeTablero estados;

    public GameObject palo2;
    public GameObject palo3;

    // Detectores de colisiones para cada palo
    public DetectorDeColisiones detectorIzquierdo2;
    public DetectorDeColisiones detectorDerecho2;
    public DetectorDeColisiones detectorIzquierdo3;
    public DetectorDeColisiones detectorDerecho3;

    public float velocidad = 30f; // Velocidad de movimiento
    public float velocidadRotacion = 500f; // Velocidad de rotación
    public float zonaMuerta = 0.1f; // Zona muerta para ignorar ruido

    // Update is called once per frame
    void Update()
    {
        // Controlar el movimiento del palo 2
        if (estados.palo2)
        {
            Mover(palo2, detectorIzquierdo2, detectorDerecho2);
        }
        // Controlar el movimiento del palo 3
        else if (estados.palo3)
        {
            Mover(palo3, detectorIzquierdo3, detectorDerecho3);
        }
    }

    void Mover(GameObject palo, DetectorDeColisiones detectorIzquierdo, DetectorDeColisiones detectorDerecho)
    {
        // Movimiento horizontal del palo usando el joystick izquierdo (Horizontal2)
        float movimiento = Input.GetAxis("Horizontal2");
        if (Mathf.Abs(movimiento) < zonaMuerta) movimiento = 0; // Aplicar zona muerta

        // Rotación del palo usando el joystick izquierdo (Vertical2)
        float rotacion = Input.GetAxis("Vertical2");
        if (Mathf.Abs(rotacion) < zonaMuerta) rotacion = 0; // Aplicar zona muerta

        // Leer el joystick derecho para rotación y movimiento avanzado
        float movimiento2 = Input.GetAxis("JoystickRightHorizontal"); // Eje Horizontal del joystick derecho
        if (Mathf.Abs(movimiento2) < zonaMuerta) movimiento2 = 0; // Aplicar zona muerta

        float rotacion2 = Input.GetAxis("JoystickRightVertical");     // Eje Vertical del joystick derecho
        if (Mathf.Abs(rotacion2) < zonaMuerta) rotacion2 = 0; // Aplicar zona muerta

        // Movimiento hacia la derecha si no hay colisión con el muro derecho
        if (movimiento > 0 && !detectorDerecho.estaColisionando)
        {
            palo.transform.Translate(Vector3.forward * velocidad * Time.deltaTime * movimiento);
        }
        // Movimiento hacia la izquierda si no hay colisión con el muro izquierdo
        else if (movimiento < 0 && !detectorIzquierdo.estaColisionando)
        {
            palo.transform.Translate(Vector3.forward * velocidad * Time.deltaTime * movimiento);
        }

        // Aplicar rotación con joystick izquierdo (Vertical2)
        if (rotacion != 0)
        {
            palo.transform.Rotate(Vector3.forward, rotacion * velocidadRotacion * Time.deltaTime);
        }

        // Movimiento avanzado con joystick derecho
        if (movimiento2 > 0 && !detectorDerecho.estaColisionando)
        {
            palo.transform.Translate(Vector3.forward * velocidad * Time.deltaTime * movimiento2);
        }
        else if (movimiento2 < 0 && !detectorIzquierdo.estaColisionando)
        {
            palo.transform.Translate(Vector3.forward * velocidad * Time.deltaTime * movimiento2);
        }

        // Aplicar rotación con joystick derecho (rotacion2)
        if (rotacion2 != 0)
        {
            palo.transform.Rotate(Vector3.forward, rotacion2 * velocidadRotacion * Time.deltaTime);
        }
    }
}
