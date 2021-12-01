using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractiveManager : MonoBehaviour
{
    public GameObject player;
    BoxCollider2D box;
    //public BoxCollider2D deskBox;
    EdgeCollider2D deskBox;
    public GameObject desk;
    // Start is called before the first frame update
    void Start()
    {
        box = player.GetComponent<BoxCollider2D>();
        deskBox = desk.GetComponent<EdgeCollider2D>();

    }
}
