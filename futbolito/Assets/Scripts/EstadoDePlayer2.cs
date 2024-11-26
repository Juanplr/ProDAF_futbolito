using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDePlayer2 : MonoBehaviour
{
    //mano player
    public bool palo5;
    public bool palo6;

    //mano I
    public bool palo7;
    public bool palo8;

    // Start is called before the first frame update
    void Start()
    {
        palo5 = true;
        palo6 = true;
        palo7 = false;
        palo8 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Controlar palo5 y palo8 (teclado y mando)
        if ((Input.GetKeyDown(KeyCode.Alpha5) || Input.GetButtonDown("LBP2")) && palo5 == false) // Tecla 1 o LB
        {
            palo5 = true;
            palo8 = false;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha8) || Input.GetAxis("LTP2") > 0.1f) && palo8 == false) // Tecla 4 o RB
        {
            palo5 = false;
            palo8 = true;
        }

        // Controlar palo2 y palo3 (teclado y mando)
        if ((Input.GetKeyDown(KeyCode.Alpha6) || Input.GetButtonDown("RBP2")) && palo6 == false) // Tecla 2 o LT
        {
            palo6 = true;
            palo7 = false;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha7) || Input.GetAxis("RTP2") > 0.1f) && palo7 == false) // Tecla 3 o RT
        {
            palo6 = false;
            palo7 = true;
        }
    }
}
