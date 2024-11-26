using UnityEngine;

public class DetectorDeColisiones : MonoBehaviour
{
    public bool estaColisionando = false; // Indica si hay colisión

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Muro"))
        {
            estaColisionando = true;
            //Debug.Log("Colisión detectada con: " + other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Muro"))
        {
            estaColisionando = false;
            //Debug.Log("Saliste de colisión con: " + other.gameObject.name);
        }
    }
}
