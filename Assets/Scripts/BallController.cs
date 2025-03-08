using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float JumpForce;
    public Rigidbody2D rb;
    public string currentColor;
    public Color colorcyan;
    public Color coloryellow;
    public Color colorpink;
    public Color colorpurple;
    public SpriteRenderer sr;

    void Start()
    {
        randomColor();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag != currentColor)
        {
            Debug.Log("Öldün");
        }
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
           rb.velocity = Vector2.up * JumpForce;
        }
    }

    void randomColor()
    {
        int index = Random.Range(0, 4);

        switch(index)
        {
            case 0 : currentColor = "Cyan";
            sr.color = colorcyan;
            break;

            case 1 : currentColor = "Yellow";
            sr.color = coloryellow;
            break;

            case 2 : currentColor = "Pink";
            sr.color = colorpink;
            break;

            case 3 : currentColor = "Purple";
            sr.color = colorpurple;
            break;
        }
    }
}
