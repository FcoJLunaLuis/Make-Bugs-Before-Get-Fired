using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class Nota : MonoBehaviour
{
    public GameObject nota;
    private GameObject notaTmp;

    public Text txtPost;

    string linea;

    // Start is called before the first frame update
    void Start()
    {
        notaTmp = nota;
        leerArchivo();
        txtPost.text = linea;

    }

    public void destroyNota()
    {
        Destroy(notaTmp);
    }

    void leerArchivo()
    {
        try
        {
            if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                string readFromPath = "MakeBugsBeforeGetFired_Data/Assets/Recursos/theboss.txt";
                linea = File.ReadAllText(readFromPath);
                //linea = "El jefe quiere verte en su oficina a las 12";
            }
            else if (Application.systemLanguage == SystemLanguage.English)
            {
                string readFromPath = "MakeBugsBeforeGetFired_Data/Assets/Recursos/thebossE.txt";
                linea = File.ReadAllText(readFromPath);
                //linea = "The boss wants to see you in his office at 12";
            }

        }
        catch
        {
            Debug.Log("Sorry bor, algo salio mal");
        }
    }


}
