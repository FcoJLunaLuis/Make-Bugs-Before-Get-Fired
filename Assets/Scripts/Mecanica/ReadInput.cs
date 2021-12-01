using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    private string _input = "";
    public GameObject textoUpdate;
    UpdateText paLaFuncion;
    // Start is called before the first frame update
    void Start()
    {  

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readInput(string input){
        paLaFuncion = new UpdateText();
        string tmp = textoUpdate.GetComponent<Text>().text;
        _input = input;
        if (_input.Equals(tmp))
        {
            Debug.Log("A huevo, funciono, la palabra es: " + tmp);
            //paLaFuncion.updateTexto(paLaFuncion.getArrPalabras());
            //paLaFuncion.updateTexto();
            paLaFuncion.setFlagText(true);
            
        }
        else {
            Debug.Log("Te equivocates krnal, la palabra era: "+tmp);
            //paLaFuncion.updateTexto(paLaFuncion.getArrPalabras());
            //paLaFuncion.updateTexto();
        }
    }
}
