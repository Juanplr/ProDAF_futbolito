using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float forceMultiplier = 10f; // Multiplicador de la fuerza aplicada
    private Rigidbody rb; // Referencia al Rigidbody del balón

    void Start()
    {
        // Obtén el Rigidbody del objeto al iniciar el juego
        rb = GetComponent<Rigidbody>();
    }

    // Este método se llama automáticamente al detectar una colisión
    private void OnCollisionEnter(Collision collision)
    {
        // Calcula la dirección de la fuerza basada en el punto de contacto
        Vector3 collisionDirection = collision.contacts[0].point - transform.position;
        collisionDirection = -collisionDirection.normalized;

        // Aplica una fuerza al balón
        rb.AddForce(collisionDirection * forceMultiplier, ForceMode.Impulse);
    }
}
