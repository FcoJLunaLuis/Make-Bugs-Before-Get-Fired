using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class titleBtnManager : MonoBehaviour
{
    private string flag;

    private void Start()
    {
        leerArchivo();
    }

    public void cerrarJuego()
    {
        Application.Quit();
    }

    public void iniciarJuego()
    {
        SceneManager.LoadScene("Tutorial");
        /*Debug.Log("Mira krnal soy: " + flag);
        bool flagB = bool.Parse(flag);
        if (flagB == true)
        {
            SceneManager.LoadScene("OficinaTemplate");
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }*/

    }

    void leerArchivo()
    {
        try
        {
            string readFromPath = "Assets/Recursos/tutorial.txt";
            flag = File.ReadAllText(readFromPath);

        }
        catch
        {
            Debug.Log("Sorry bor, algo salio mal");
        }
    }
}
