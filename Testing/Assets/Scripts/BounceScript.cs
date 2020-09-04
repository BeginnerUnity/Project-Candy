using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public bool active = true;
    public float range = 1;
    public float speed = 1;

    private Vector3 startPosition;
    private bool movingDown = true;
    private float displacement = 0f;

    
    void Awake()
    {
        startPosition = this.transform.localPosition;
    }

    void Update()
    {
        if(active)
        {
            if(movingDown)
            {
                if(displacement <= range)
                {
                    this.transform.Translate(Vector3.down * speed * Time.deltaTime);
                    displacement = displacement + (speed * Time.deltaTime);
                }
                else
                {
                    movingDown = false;
                }
            }
            else
            {
                if(displacement >= 0)
                {
                    this.transform.Translate(Vector3.up * speed * Time.deltaTime);
                    displacement = displacement - (speed * Time.deltaTime);
                }
                else
                {
                    movingDown = true;
                }
            }
        }
    }
}
