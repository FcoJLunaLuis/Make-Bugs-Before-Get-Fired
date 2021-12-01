using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    //public GameObject texto;
    public InputField cuadroTexto;
    Text textoUpdate;
    private string[] arrPalabras;
    private int rnd;
    bool flagText;

    // Start is called before the first frame update
    void Start()
    {
        rnd = 0;
        arrPalabras = new string[] { "Algo", "No", "Se", "Que", "Escribir", "Aqui", "Tal", "Vez", "Algo", "Chido", "Se", "Me", "Ocurrira" };
        //textoUpdate = texto.GetComponent<Text>();
        updateTexto(arrPalabras);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flagText)
        {
            rnd = Random.Range(0, 14);
            limpiarCampo();
            Debug.Log("Que onda bro, entre en el if");
            flagText = false;
            textoUpdate.text = arrPalabras[rnd];
        }
        /**else
        {
            cuadroTexto.text = "";
            cuadroTexto.Select();
            cuadroTexto.ActivateInputField();
        }**/
    }

    void limpiarCampo()
    {
        cuadroTexto.text = " ";
    }

    public void updateTexto(string[] arr) {
        int rnd = (int)Random.Range(0f, 12f);
        string v = arr[rnd];
        Debug.Log(arr.Length);
        Debug.Log(v);
        textoUpdate.text = v;
    }
    public void updateTexto()
    {
        rnd = Random.Range(0, 14);
        textoUpdate.text = arrPalabras[rnd];
    }

    public string[] getArrPalabras()
    {
        return arrPalabras;
    }

    public void setFlagText(bool f)
    {
        flagText = f;
    }
    void imprimir()
    {
        for (int i =0; i< arrPalabras.Length; i++) {
            Debug.Log(arrPalabras[i]);
        }

    }
}
