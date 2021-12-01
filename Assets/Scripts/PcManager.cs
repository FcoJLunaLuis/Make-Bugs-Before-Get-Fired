using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcManager : MonoBehaviour
{
    public GameObject desk;
    public GameObject mecanica;
    GameObject _mecanica;
    // Start is called before the first frame update
    void Start()
    {
        desk.GetComponent<EdgeCollider2D>();
        _mecanica = mecanica;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("La estoy toucheando bro!!");
                if (GameObject.FindGameObjectWithTag("Mecanica") == false)
                {
                    cambiarAMecanica();
                }
                
            }
        }
    }

    void cambiarAMecanica()
    {
        Instantiate(_mecanica, new Vector3(0,0,0),Quaternion.identity);
    }
}
