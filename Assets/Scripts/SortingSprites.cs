using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSprites : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase;
    private Renderer myRender;
    [SerializeField]
    private int offset;
    [SerializeField]
    private bool runOnlyOnce = false;

    private float timer;
    private float timerMax = 0.1f;
    
    private void Awake()
    {
        myRender = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            timer = timerMax;
            myRender.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }
}
