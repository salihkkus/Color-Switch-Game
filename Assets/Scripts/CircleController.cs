using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float speed;
    public bool direction;



    void Update()
    {
        if(direction == false)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -1 * speed * Time.deltaTime);
        }
    }

}

    
