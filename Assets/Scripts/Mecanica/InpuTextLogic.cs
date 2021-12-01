using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class InpuTextLogic : MonoBehaviour
{
    public InputField cuadroTexto;
    public Text textoUpdate;
    public Text scoreText;
    public Text erroesText;
    public Text timerText;
    public GameObject timerManager;


    int erroresCount;
    int score;
    private string[] arrPalabras;
    bool flagText;
    private string _input = "";

    public List<string[]> frasesInGame;
    private string[] lasFrases;
    private int numAcWord;
    private int numFrase;

    private GameObject _mecanica;

    //private int _scoreMax = 20;
    //private int _scoreMax2 = 25;

    private int numDesk;
    private int _horas;
    private int _minutos;
    private Text textoHoras;

    GameObject musica;

    private void Awake()
    {
        loadData();
        musica = GameObject.FindGameObjectWithTag("Musica");
        musica.GetComponent<AudioSource>().Pause();
        scoreText.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        cuadroTexto.ActivateInputField();
        score = 0;
        erroresCount = 0;
        scoreText.text = "0";
        erroesText.text = " ";
        numAcWord = 1;
        numFrase = 0;
        numDesk = 0;
        frasesInGame = new List<string[]>();
        leerArchivo();
        escogerFrases();
        getNumDesk();
        _mecanica = GameObject.FindGameObjectWithTag("Mecanica");
        textoHoras = GameObject.FindGameObjectWithTag("Texto").GetComponent<Text>();
        
        calcularTiempo();
        updateTexto(getPalabra());
        
    }

    public void readInput(string input)
    {
        char s = ' ';
        string tmp = textoUpdate.text;
        _input = input;
        string newtmp = tmp.Trim(s);

        if (isTutorial() == true)
        {
            if (_input.Equals(newtmp))
            {
                limpiarCampo();
                updateTexto(getPalabra());
            }
            else
            {
                limpiarCampo();
            }
        }
        else
        {
            if (_input.Equals(newtmp))
            {
                limpiarCampo();
                addScore();
                updateTexto(getPalabra());
            }
            else
            {
                limpiarCampo();
                addError();
            }
        }

        
    }

    bool isTutorial()
    {
        bool flag = false;
        if (GameObject.FindGameObjectWithTag("Tutorial") == true)
        {
            flag = true;
            scoreText.gameObject.SetActive(false);
        }
        return flag;
    }
    void updateTexto(string[] arr)
    {
        string v = arr[1];
        Debug.Log(v);
        textoUpdate.text = v;
    }

    void updateTexto(string tmp)
    {
        if(tmp.Equals("a"))
        {
            updateTexto(getPalabra());
        }
        else if (tmp != null) {
            textoUpdate.text = tmp;
        }
        else
        {
            timerManager.GetComponent<TimerManager>().setGameOver(true);
            timerText.text = "Game Over";
            cuadroTexto.enabled = false;
        }
        
    }

    void limpiarCampo()
    {
        cuadroTexto.text = "";
        cuadroTexto.Select();
        cuadroTexto.ActivateInputField();
    }

    void addScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score > 20)
        {
            Destroy(_mecanica);
        }
    }

    void addError()
    {
        erroresCount++;
    }

    void calcularTiempo()
    {
        _minutos = erroresCount * 15;
        if (_minutos >= 60)
        {
            while (_minutos >= 60)
            {
                _minutos = _minutos - 60;
                _horas++;
            }
        }
        setHora(_horas,_minutos);
    }
    void setHora(int horas, int minutos)
    {
        if (horas.ToString().Length > 1)
        {
            if (minutos.ToString().Length > 1)
            {
                textoHoras.text = horas + ":" + minutos;
            }
            else
            {
                textoHoras.text = horas + ":0" + minutos;
            }

        }
        else
        {
            if (_minutos.ToString().Length > 1)
            {
                textoHoras.text = "0" + horas + ":" + minutos;
            }
            else
            {
                textoHoras.text = "0" + horas + ":0" + minutos;
            }
        }
    }

    /*void addError()
    {
        string xError = "X";
        erroresCount++;
        if (erroresCount <= 3)
        {
            erroesText.text = erroesText.text + xError;
        }
        if (erroresCount >= 3 && erroresCount < 4)
        {
            timerManager.GetComponent<TimerManager>().setGameOver(true);
            timerText.text = "Game Over";
            cuadroTexto.enabled = false;
        }

    }*/

    void leerArchivo()
    {

        try
        {
            if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                string readFromPath = "MakeBugsBeforeGetFired_Data/Assets/Recursos/text.txt";
                lasFrases = File.ReadAllLines(readFromPath).ToArray();
            }else if (Application.systemLanguage == SystemLanguage.English)
            {
                string readFromPath = "MakeBugsBeforeGetFired_Data/Assets/Recursos/textE.txt";
                lasFrases = File.ReadAllLines(readFromPath).ToArray();
            }
            
        }
        catch
        {   
            Debug.Log("Sorry bor, algo salio mal");
        }
    }

    void escogerFrases()
    {
        int numFrases = lasFrases.Length;
        int numPalabras = 0;
        int countAl = 0;
        while (numPalabras < 20 )
        {
            int rndFrase = Random.Range(1, numFrases);
            string[] frases = lasFrases[rndFrase].Split(' ');
            numPalabras += int.Parse(frases[0]);
            countAl++;
            Debug.Log("ira wacha soy la frase " + countAl + " y tengo esta cantidad de palabras " + numPalabras);
            frasesInGame.Add(frases);
            /*if (numPalabras < 20)
            {
                string[] frases = lasFrases[rndFrase].Split(' ');
                numPalabras +=  int.Parse(frases[0]);
                Debug.Log("Wacha Si entro en escogerFrase");
                frasesInGame.Add(frases);
            }else if (numPalabras > 20)
            {
                frasesInGame.RemoveAt(frasesInGame.Count - 1);
            }*/

        }

    }

    private string getPalabra()
    {
        if (numFrase <= frasesInGame.Count)
        {
            string[] tmp = frasesInGame[numFrase];
            if (numAcWord < tmp.Length)
            {
                string sTmp = tmp[numAcWord];
                numAcWord++;
                return sTmp;
            }
            Debug.Log("voy en la frase"+numFrase);
            numFrase++;
            numAcWord = 1;
            return "a";
        }
        Debug.Log("Me sali del if we que pedo? numfrase: "+numFrase);
        return null;
    }

    private void getNumDesk()
    {
        numDesk += GameObject.FindGameObjectsWithTag("Desk").Length;
    }

    private void saveData()
    {
        PlayerPrefs.SetInt("aciertos",score);
        PlayerPrefs.SetInt("errores",erroresCount);
        PlayerPrefs.SetInt("desk",numDesk);
        PlayerPrefs.SetInt("horas", _horas);
        PlayerPrefs.SetInt("minutos", _minutos);

    }

    private void loadData()
    {
        score = PlayerPrefs.GetInt("aciertos",0);
        erroresCount = PlayerPrefs.GetInt("errores", 0);
        numDesk = PlayerPrefs.GetInt("desk", 0);
        _horas = PlayerPrefs.GetInt("horas", 0);
        _minutos = PlayerPrefs.GetInt("minutos", 0);
    }

    

    private void OnDestroy()
    {
        musica.GetComponent<AudioSource>().Play();
        calcularTiempo();
        saveData();
    }

}
