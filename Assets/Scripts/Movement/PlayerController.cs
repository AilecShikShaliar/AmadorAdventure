using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public bool lookingleft = true; //para ver a qué direccion mira el sprite
    //public bool canInteract = false; 
    private Rigidbody2D _theRB;
    //faltan las referencias al animator y al sprite, pero eso ya lo pondremos más adelante cuando hayan sprites y animaciones


    void Start()
    {
        _theRB = GetComponent<Rigidbody2D>();
        //_anim = GetComponent<Animator>();
        //_theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * 2, _theRB.velocity.y);
            //anim.Setbool(jdfguih35uig)
        }
        else
        {
            _theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, _theRB.velocity.y);
            //anim.Setbool("90i38490) FALSO AAAAAAAAAAAAAAAAAAAAAAAAA
        }
    }
}
