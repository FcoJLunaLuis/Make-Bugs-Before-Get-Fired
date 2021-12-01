using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionText : MonoBehaviour
{
    public Text titulo;
    private float delay = 0.09f;
    private string currentText = "";
    private string texto;
    bool activar;
    // Start is called before the first frame update
    void Start()
    {
        activar = false;
        texto = titulo.text;
        StartCoroutine(ShowText());
        activar = true;
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < texto.Length;i++)
        {
            currentText = texto.Substring(0,i);
            titulo.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        
    }

    public bool getActivar()
    {
        return activar;
    }
}
