using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarOficina : MonoBehaviour
{
    public GameObject[] oficinas;
    public GameObject puntoInicio;
    GameObject _oficina;
    // Start is called before the first frame update
    void Start()
    {
        GameObject oficina;

        int rndOficinas = Random.Range(0, oficinas.Length);
        oficina = Instantiate(oficinas[rndOficinas], puntoInicio.transform.position, Quaternion.identity);
        _oficina = oficina;
    }
}
