using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionarEquipo : MonoBehaviour
{
   public void irMenuPrincipal(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Debug.Log("Debe volver al menu principal");
    }

 

    public void irPantallaJuego(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Debug.Log("Continuara al juego");   
    }

  

}
