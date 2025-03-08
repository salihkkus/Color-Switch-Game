using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float speed;
    public bool direction;
    public string currentColor;
    public Color colorcyan;
    public Color coloryellow;
    public Color colorpink;
    public Color colorpurple;
    public SpriteRenderer sr;

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

    public void randomColor()
    {
        int index = Random.Range(0, 4);

        switch(index)
        {
            case 0 : currentColor = "cyan";
            sr.color = colorcyan;
            break;

            case 1 : currentColor = "yellow";
            sr.color = coloryellow;
            break;

            case 2 : currentColor = "pink";
            sr.color = colorpink;
            break;

            case 3 : currentColor = "purple";
            sr.color = colorpurple;
            break;
        }
    }
}
