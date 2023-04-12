using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables

    [Header("Parametros de movimiento"),Space]
    [Tooltip("Velocidad de movimiento")]
    public float speed;
    //Referencia al valor del input axis horizontal
    float h;
    //Referencia al valor del input axis vertical
    float v;

    Vector2 movement;

        
    [Header("Limites de pantalla"), Space]
    [Tooltip("Limite de movimiento en el eje X")]
    public float xLimit;
    [Tooltip("Limite de movimiento en el eje Y")]
    public float yLimit;


    //Referencia al rigidbody
    private Rigidbody2D rb2d;


    private void Awake() 
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    private void Update() 
    {
        AxisDetec();
    }
    private void FixedUpdate() 
    {
        Movement();
        Border();
    }

    /// <summary>
    ///  recuperamos los valores de los axis horizontal y vertical
    /// </summary>
    private void AxisDetec() 
    {

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

    }


    /// <summary>
    /// Metodo que usarenos para realizar el movimiento del jugador
    /// </summary>
    private void Movement() 
    {

        

        //Generamos un vector de movimiento y lo normalizamos

        movement = new Vector2(h, v).normalized;

        //Aplicamos el movimiento sobre el jugador
        rb2d.MovePosition((Vector2) transform.position + movement * speed * Time.deltaTime);

    }

    private void Border() 
    {
            
        //Si el la posicion en x es superior a el limite de x 
        if (transform.position.x > xLimit) {
            //la posicion del personaje se seteara al limite del borde
            transform.position = new Vector2(xLimit, transform.position.y);
        }
        //Si el la posicion en x es superior a el limite de x 
        if (transform.position.x < -xLimit)
        {   //la posicion del personaje se seteara al limite del borde
            transform.position = new Vector2(-xLimit, transform.position.y);
        }



        //Si el la posicion en y es superior a el limite de y 
        if (transform.position.y > yLimit)
        {   //la posicion del personaje se seteara al limite del borde
            transform.position = new Vector2(transform.position.x, yLimit);
        }
        //Si el la posicion en y es superior a el limite de y 
        if (transform.position.y < -yLimit)
        {   //la posicion del personaje se seteara al limite del borde
            transform.position = new Vector2(transform.position.x, -yLimit );
        }
   

    }








}
