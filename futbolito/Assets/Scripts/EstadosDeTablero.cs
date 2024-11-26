using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosDeTablero : MonoBehaviour
{
    //mano player
    public bool palo4;
    public bool palo1;

    //mano I
    public bool palo2;
    public bool palo3;

    // Start is called before the first frame update
    void Start()
    {
        palo1 = true;
        palo2 = true;
        palo3 = false;
        palo4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Controlar palo1 y palo4 (teclado y mando)
        if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("LB")) && palo1 == false) // Tecla 1 o LB
        {
            palo1 = true;
            palo4 = false;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetAxis("LT") > 0.1f) && palo4 == false) // Tecla 4 o RB
        {
            palo1 = false;
            palo4 = true;
        }

        // Controlar palo2 y palo3 (teclado y mando)
        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("RB")) && palo2 == false) // Tecla 2 o LT
        {
            palo2 = true;
            palo3 = false;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetAxis("RT") > 0.1f) && palo3 == false) // Tecla 3 o RT
        {
            palo2 = false;
            palo3 = true;
        }
    }
}
