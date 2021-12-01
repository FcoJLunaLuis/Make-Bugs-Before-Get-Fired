using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTimeTutorial : MonoBehaviour
{
    private int _horas;
    private int _minutos;
    private Text texto;

    private void Awake()
    {
        loadData();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Las horas we: "+_horas);
        Debug.Log("Los minutos we: " + _minutos);
        texto = GameObject.FindGameObjectWithTag("Texto").GetComponent<Text>();
        setHora();
    }

    void setHora()
    {
        if (_horas.ToString().Length > 1)
        {
            texto.text = _horas + ":0" + _minutos;
        }
        else
        {
            texto.text = "0" + _horas + ":0" + _minutos;
        }
    }

    void loadData()
    {
        _horas = PlayerPrefs.GetInt("hora", 0);
        _minutos = PlayerPrefs.GetInt("minutos", 0);
    }
}
