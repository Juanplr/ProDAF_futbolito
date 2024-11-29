using UnityEngine;
using TMPro;

public class GoalCounter : MonoBehaviour
{
    // Referencias a los textos del marcador
    public TextMeshProUGUI barcelonaText;
    public TextMeshProUGUI madridText;

    // Referencia al balón
    public GameObject balon;

    // Posición inicial del balón
    private Vector3 initialBallPosition;

    // Contadores de goles
    private int barcelonaGoals = 0;
    private int madridGoals = 0;

    // Método inicial
    void Start()
    {
        // Captura la posición inicial del balón
        initialBallPosition = balon.transform.position;

        // Inicializa los textos del marcador
        UpdateScoreTexts();
    }

    // Detecta colisión
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el balón
        if (collision.gameObject.CompareTag("Balon"))
        {
            // Verificar si esta es la portería de Barcelona
            if (gameObject.CompareTag("PorteriaB"))
            {
                AddGoalMadrid();
            }
            // Verificar si esta es la portería de Madrid
            else if (gameObject.CompareTag("PorteriaRM"))
            {
                AddGoalBarcelona();
            }

            // Mover el balón a su posición inicial
            ResetBallPosition();
        }
    }

    // Incrementa los goles de Barcelona
    private void AddGoalBarcelona()
    {
        barcelonaGoals++;
        UpdateScoreTexts();
    }

    // Incrementa los goles de Madrid
    private void AddGoalMadrid()
    {
        madridGoals++;
        UpdateScoreTexts();
    }

    // Actualiza ambos textos del marcador
    private void UpdateScoreTexts()
    {
        barcelonaText.text = "Barcelona: " + barcelonaGoals;
        madridText.text = "Madrid: " + madridGoals;
    }

    // Reinicia la posición del balón
    private void ResetBallPosition()
    {
        // Detener el movimiento del balón
        Rigidbody ballRigidbody = balon.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector3.zero; // Detener velocidad
            ballRigidbody.angularVelocity = Vector3.zero; // Detener rotación
        }

        // Colocar el balón en su posición inicial
        balon.transform.position = initialBallPosition;
    }
}
