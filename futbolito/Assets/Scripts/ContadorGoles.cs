using UnityEngine;
using TMPro;

public class GoalCounter : MonoBehaviour
{
    // Referencias a los textos de marcador
    public TextMeshProUGUI barcelonaText;
    public TextMeshProUGUI madridText;

    // Contadores de goles
    private int barcelonaGoals = 0;
    private int madridGoals = 0;

    // Inicialización
    void Start()
    {
        UpdateScoreTexts();
    }

    // Incrementa los goles de Barcelona
    public void AddGoalBarcelona()
    {
        barcelonaGoals++;
        UpdateScoreTexts();
    }

    // Incrementa los goles de Madrid
    public void AddGoalMadrid()
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
}
