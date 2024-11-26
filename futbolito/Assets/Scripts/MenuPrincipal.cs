using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{

    public void Iniciar(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Debug.Log("Debe pasar a modos de juego");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Se cierra el juego");
    }
}
