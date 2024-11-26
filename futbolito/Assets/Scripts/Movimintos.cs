using UnityEngine;

public class Movimintos : MonoBehaviour
{
    public DetectorDeColisiones detectorIzquierdo; // Detector para el lado izquierdo
    public DetectorDeColisiones detectorDerecho;  // Detector para el lado derecho
    public float velocidad = 30f; // Velocidad de movimiento
    public float velocidadRotacion = 500f; // Velocidad de rotación

    void Update()
    {
        // Movimiento horizontal
        float movimiento = Input.GetAxis("Horizontal");

        // Rotación
        float rotacion = Input.GetAxis("Vertical"); // Usa el eje Vertical para controlar la rotación


        // Permitir el movimiento hacia la derecha si no está colisionando con el muro derecho
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
