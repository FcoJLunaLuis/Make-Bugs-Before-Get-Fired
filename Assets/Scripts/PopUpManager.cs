using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{

    string[] palabras;
    string[] palabrasE;
    Text text;
    public float lifeTime;

    private void Awake()
    {
        this.GetComponent<Animator>().SetBool("PopUp",true);
    }
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponentInChildren<Text>();
        palabras = new string[]{"Ya no se puede","Que intentas hacer?", "Ve a la siguiente", "Nope" };
        palabrasE = new string[] { "It can not be anymore", "What are you trying to do?", "Next", "Nope" };
        text.text = rndFrase();
    }

    private void Update()
    {
        if (lifeTime <= 0)
        {
            Debug.Log("Me destrui we qwq");
            Destroy(this);
        }
        else
        {
            Debug.Log("El tiempo: " + lifeTime);
            lifeTime -= Time.deltaTime;
        }
    }

    string rndFrase()
    {
        int rnd = Random.Range(0, palabras.Length);
        if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            return palabras[rnd];
        }else
        {
            return palabrasE[rnd];
        }
    }
}
