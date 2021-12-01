using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalManager : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Text texto;
    private int porcentajeAciertos;

    private int _aciertos;
    private int _palabras = 20;
    private int _desk;
    private int _horas;

    private Animator animator;
    private AudioSource audioS;
    public AudioClip[] clips;

    private void Awake()
    {
        loadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        porcentajeAciertos = 0;
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        animator = this.gameObject.GetComponent<Animator>();
        audioS = this.gameObject.GetComponent<AudioSource>();
        escogerFinal(calcularPorcentaje());
    }

    int calcularPorcentaje()
    {
        if (_aciertos != 0)
        {
            porcentajeAciertos = _aciertos / (_palabras * _desk);
            porcentajeAciertos = porcentajeAciertos * 100;
            return porcentajeAciertos;
        }
        else
        {
            return porcentajeAciertos;
        }
        
    }

    private void loadData()
    {
        _aciertos = PlayerPrefs.GetInt("aciertos");
        _desk = PlayerPrefs.GetInt("desk");
        _horas = PlayerPrefs.GetInt("horas", 0);
    }


    private void escogerFinal(int porcentaje)
    {
        if (_horas > 12)
        {
            audioS.clip = clips[1];
            audioS.Play(0);
            animator.SetBool("Carcel",true);
            //sprite.sprite = finales[5];
        }

        if (porcentaje == 0)
        {
            audioS.clip = clips[2];
            audioS.Play(0);
            animator.SetBool("0",true);
            //sprite.sprite = finales[0];
        }else if (porcentaje > 0 && porcentaje < 50)
        {
            audioS.clip = clips[0];
            audioS.Play(0);
            animator.SetBool("25", true);
            //sprite.sprite = finales[1];
        }
        else if (porcentaje > 50 && porcentaje < 75)
        {
            audioS.clip = clips[0];
            audioS.Play(0);
            animator.SetBool("50", true);
            //sprite.sprite = finales[2];
        }
        if (porcentaje > 75 && porcentaje < 100)
        {
            audioS.clip = clips[0];
            audioS.Play(0);
            animator.SetBool("75", true);
            //sprite.sprite = finales[3];
        }
        if (porcentaje == 100)
        {
            audioS.clip = clips[0];
            audioS.Play(0);
            animator.SetBool("100", true);
            //sprite.sprite = finales[4];
        }

        if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            texto.text = "Tu porcentaje de bugs fue: " + porcentaje + "%";
        }
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            texto.text = "Your error rate was: " + porcentaje + "% ";
        }
    }

    private void OnDestroy()
    {
        audioS.Stop();
    }

}
