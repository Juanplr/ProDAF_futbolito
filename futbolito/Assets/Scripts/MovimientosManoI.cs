using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosManoI : MonoBehaviour
{

    public DetectorDeColisiones detectorIzquierdo; // Detector para el lado izquierdo
    public DetectorDeColisiones detectorDerecho;  // Detector para el lado derecho
    public float velocidad = 30f; // Velocidad de movimiento
    public float velocidadRotacion = 500f; // Velocidad de rotación

    // Update is called once per frame
    void Update()
    {
        // Movimiento horizontal segundo palo
        float movimiento = Input.GetAxis("Horizontal2");

        // Rotación segundo palo
        float rotacion = Input.GetAxis("Vertical2"); // Usa el eje Vertical para controlar la rotación
                                                     // Start is called before the first frame update
        if (movimiento > 0 && !detectorDerecho.estaColisionando)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime * movimiento);
        }
        // Permitir el movimiento hacia la izquierda si no está colisionando con el muro izquierdo
        else if (movimiento < 0 && !detectorIzquierdo.estaColisionando)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime * movimiento);
        }
        else
        {
            Debug.Log("Movimiento restringido debido a una colisión con un muro.");
        }

        // Aplicar rotación
        if (rotacion != 0)
        {
            transform.Rotate(Vector3.forward, rotacion * velocidadRotacion * 2f * Time.deltaTime);
        }
    }
}
