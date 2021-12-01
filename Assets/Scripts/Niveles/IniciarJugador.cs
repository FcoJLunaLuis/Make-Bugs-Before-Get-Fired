using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJugador : MonoBehaviour
{
    public GameObject jugador;
    public GameObject puntoInicial;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(jugador,puntoInicial.transform.position,Quaternion.identity);
    }

}
