using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    public GameObject[] prefabRoom;
    public GameObject[] prefabDesk;
    GameObject puntoInicial;
    BoxCollider2D boxDoor;

    private int _horas;

    private void Awake()
    {
        loadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        puntoInicial = GameObject.Find("PuntoInicialJugador");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_horas > 12)
            {
                SceneManager.LoadScene("Final");
            }
            else
            {
                SceneManager.LoadScene("OficinaTemplate");
            }
            
        }
    }

    void loadData()
    {
        _horas = PlayerPrefs.GetInt("horas", 0);
    }
  
}
