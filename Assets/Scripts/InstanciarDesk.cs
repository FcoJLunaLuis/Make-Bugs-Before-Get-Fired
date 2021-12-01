using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarEscritorios : MonoBehaviour
{
    public GameObject[] escritorios;
    public GameObject puntoInicio;
    GameObject _escritorio;
    // Start is called before the first frame update
    void Start()
    {
        GameObject escritorio;
        int rndDesk = Random.Range(0, escritorios.Length);
        Debug.Log("Wacha que numero de escritorio soy bro" + rndDesk);
        escritorio = Instantiate(escritorios[rndDesk], puntoInicio.transform.position, Quaternion.identity);
        _escritorio = escritorio;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            destruirEscenario(_escritorio);
            int rndDesk = Random.Range(0, escritorios.Length);
            Debug.Log("Wacha que numero de escritorio soy bro" + rndDesk);
            _escritorio = Instantiate(escritorios[rndDesk], puntoInicio.transform.position, Quaternion.identity);
        }
    }

    void destruirEscenario(GameObject oficina)
    {
        Destroy(oficina, 0.001f);
    }
}
