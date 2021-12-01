using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public float speedMov;
    Rigidbody2D rbody;
    private Vector2 direction;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
        rbody = player.GetComponentInChildren<Rigidbody2D>();
        
    }


    private void FixedUpdate()
    {
        
        Vector2 currectPos = rbody.position;
        float dirX = Input.GetAxis("Horizontal"); 
        float dirY = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", dirX);
        animator.SetFloat("Vertical", dirY);
        animator.SetFloat("Speed",direction.sqrMagnitude);

        direction.Set(dirX,dirY);
        Vector2 movement = direction * speedMov;
        Vector2 newPos = currectPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
        
    }


}
