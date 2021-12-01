using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timer;
    public float timeLeft;
    public InputField cuadroTexto;
    private Text textoInput;
    private bool gameover;
    private GameObject _mecanica;
    // Start is called before the first frame update
    void Start()
    {
        textoInput = cuadroTexto.GetComponentInChildren<Text>();
        gameover = false;
        _mecanica = GameObject.FindGameObjectWithTag("Mecanica");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            if (gameover == false)
            {
                timeLeft -= Time.deltaTime;
                mostrarTiempo(timeLeft);
            }
            else
            {
                timeLeft = 0f;
            }
        }
        if(timeLeft<=0)
        {
            timeLeft = 0;
            timer.text = timeLeft.ToString();

            cuadroTexto.enabled = false;
            Destroy(_mecanica);
            return;
        }
        
    }
    
    void mostrarTiempo(float tiempoAMostrar)
    {
        if (tiempoAMostrar < 0) {
            tiempoAMostrar = 0;
        }


        

        //float minutos = Mathf.FloorToInt(tiempoAMostrar/60);
        float segundos = Mathf.FloorToInt(tiempoAMostrar % 60);
        float miliSegundos = tiempoAMostrar % 1 * 1000;

        timer.text = string.Format("{0:00}:{1:000}",segundos,miliSegundos);
    }
    public void setGameOver(bool flag)
    {
        gameover = flag;
    }
}
