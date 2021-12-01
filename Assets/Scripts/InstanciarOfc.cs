using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarNivel : MonoBehaviour
{
    public GameObject[] oficinas;
    public GameObject puntoInicio;
    GameObject _oficina;
    // Start is called before the first frame update
    void Start()
    {
        GameObject oficina;
        
        int rndOficinas = Random.Range(0,oficinas.Length);
        Debug.Log("Wacha que numero de oficina soy bro" + rndOficinas);
        

        oficina = Instantiate(oficinas[rndOficinas], puntoInicio.transform.position, Quaternion.identity);
        

        _oficina = oficina;
       




    }

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            destruirEscenario(_oficina);
            int rndOficinas = Random.Range(0, oficinas.Length);
            Debug.Log("Wacha que numero de oficina soy bro" + rndOficinas);
            _oficina = Instantiate(oficinas[rndOficinas], puntoInicio.transform.position, Quaternion.identity);
        }
    }

    void destruirEscenario(GameObject oficina)
    {
        Destroy(oficina, 0.001f);
    }
}
