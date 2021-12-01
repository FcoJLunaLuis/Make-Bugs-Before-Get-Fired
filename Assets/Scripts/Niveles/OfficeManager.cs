using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfficeManager : MonoBehaviour
{

    private int numOfActual;
    private int numOficinas;

    private void Awake()
    {
        loadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        addOff();
        final();
        Debug.Log("La oficina actual es: " + numOfActual);
        Debug.Log("Las oficinas son: " + numOficinas);
    }

    private void addOff()
    {
        numOfActual++;
    }

    private void final()
    {
        if (numOfActual > numOficinas)
        {
            SceneManager.LoadScene("Final");
        }
    }

    private void saveData()
    {
        PlayerPrefs.SetInt("numOficinas", numOfActual);
    }

    private void loadData()
    {
        numOfActual = PlayerPrefs.GetInt("numOficinas", 0);
        numOficinas = PlayerPrefs.GetInt("numTotalOf", 0);
    }

    private void OnDestroy()
    {
        saveData();
    }
}
