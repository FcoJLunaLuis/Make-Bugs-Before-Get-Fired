using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class IniciarTutorial : MonoBehaviour
{
    public GameObject oficina;
    public GameObject desk;
    public GameObject player;
    public GameObject puntoInicailPlayer;
    public GameObject puntoInicialOf;
    public GameObject puntoInicialDsk;

    public GameObject nota;
    private GameObject notaTmp;

    public Text txtPost;
    string linea;

    private void Awake()
    {
        leerArchivo();
    }

    // Start is called before the first frame update
    void Start()
    {
        notaTmp = nota;
        //leerArchivo();
        txtPost.text = linea;
    }

    void destroyNota()
    {
        //writeFile("true");
        Destroy(notaTmp);
    }

    public void iniciarTutorial()
    {
        destroyNota();
        Instantiate(oficina, puntoInicialOf.transform.position, Quaternion.identity);
        Instantiate(desk, puntoInicialDsk.transform.position, Quaternion.identity);
        Instantiate(player, puntoInicailPlayer.transform.position, Quaternion.identity);
    }

    void leerArchivo()
    {
        try
        {
            if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                string readFromPath = "MakeBugsBeforeGetFired_Data/Assets/Recursos/Instrucciones.txt";
                linea = File.ReadAllText(readFromPath);
                /*linea = "1.- Acércate a una computadora y presiona \n"+
                    "espacio para interactuar.\n" +
                    "2.- ASWD para moverte.\n" +
                    "3.- Crea bugs en el código de la empresa antes de que te despidan.\n" +
                    "4.- Escribe las palabras que aparecerán en pantalla.\n" +
                    "5.- Si te equivocas el tiempo avanzara mas rápido.\n" +
                    "6.- ...\n" +
                    "7.- Tu puedes, confió en ti < 3 ";*/
            }
            else if (Application.systemLanguage == SystemLanguage.English)
            {
                string readFromPath = "MakeBugsBeforeGetFired_Data/Assets/Recursos/InstruccionesE.txt";
                linea = File.ReadAllText(readFromPath);
                /*linea = "1.- Approach a computer and press space to interact.\n"+
                        "2.- ASWD to move.\n"+
                        "3.- Create bugs in company code before get fired.\n"+
                        "4.- Write the words that will appear on the screen.\n"+
                        "5.- If you make a mistake, time moves faster.\n"+
                        "6.- ...\n"+
                        "7.- You can, I trust you < 3\n";*/
            }

        }
        catch
        {
            Debug.Log("Sorry bor, algo salio mal");
        }
    }

    private void writeFile(string flag)
    {
        string path = "Assets/Recursos/tutorial.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(flag);
        writer.Close();
    }

}
