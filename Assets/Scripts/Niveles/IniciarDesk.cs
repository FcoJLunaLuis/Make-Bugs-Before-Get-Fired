using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarDesk : MonoBehaviour
{
    public GameObject[] escritorios;
    public GameObject puntoInicio;
    GameObject _escritorio;
    // Start is called before the first frame update
    void Start()
    {
        GameObject escritorio;
        int rndDesk = Random.Range(0, escritorios.Length);
        escritorio = Instantiate(escritorios[rndDesk], puntoInicio.transform.position, Quaternion.identity);
        _escritorio = escritorio;
    }

}
