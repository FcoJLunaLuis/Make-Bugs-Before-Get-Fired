using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IniciarVariables : MonoBehaviour
{
    private int aciertos;
    private int erroes;
    private int desk;
    private int numOficinas;
    private int _numOff;
    private int _hora;
    private int _minutos;

    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        aciertos = 0;
        erroes = 0;
        desk = 0;
        numOficinas = 0;
        _minutos = 0;
        _hora = 0;
        Debug.Log(Application.dataPath);
        texto.text = Application.dataPath;
        rndOffices();
        calcularHora();
    }

    private void rndOffices()
    {
        _numOff = Random.Range(2, 4);
    }

    private void calcularHora()
    {
        _hora = 12 - _numOff;
        Debug.Log("Las horas we!!: "+_hora);
    }

    private void saveData()
    {
        PlayerPrefs.SetInt("aciertos",aciertos);
        PlayerPrefs.SetInt("errores",erroes);
        PlayerPrefs.SetInt("desk",desk);
        PlayerPrefs.SetInt("numOficinas",numOficinas);
        PlayerPrefs.SetInt("numTotalOf",_numOff);
        PlayerPrefs.SetInt("hora", _hora);
        PlayerPrefs.SetInt("minutos", _minutos);

    }

    private void OnDestroy()
    {
        saveData();
    }

}
