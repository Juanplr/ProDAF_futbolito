using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionarEquipo : MonoBehaviour
{
   public void volver(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Debug.Log("Debe volver al menu principal");
    }

    public void ajustes(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Debug.Log("Debe ir a la pantalla de ajustes");
    }

    public void continuar(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Debug.Log("Continuara al juego");   
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("Se cierra el juego");
    }

}
