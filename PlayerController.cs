using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;

    void Start ()
    {
        //inicializamos los elementos
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        //asignamos los ejes verticales y horizontales del RigidBody
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        //los añadimos al vector de movimiento
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        //asigna la fuerza al RigidBody, usando el resultado de multiplicar el movimiento por la velocidad
        rb.AddForce (movement * speed);

        //reinicia la escena si el jugador se cae de la plataforma, es decir, si su posición es menor que la indicada
        if(transform.position.y <= -20)
        {
            winText.text = "You Lose!";
            StartCoroutine(RestartScene());
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        //si el objeto con el que colisiona el jugador es uno de los cubos que hay que recoger, es decir, que tenga el siguiente tag...
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            //lo hace invisible
            other.gameObject.SetActive (false);
            //suma 1 a la puntuacion total
            count = count + 1;
            //actualiza el texto que lleva la cuenta de los puntos
            SetCountText ();
        }

        //HAY QUE SELECCIONAR IS TRIGGER EN ENEMY, SINO NO FUNCIONA
        //si el objeto con el que colisiona el jugador es el enemigo...
        if(other.gameObject.CompareTag ("Enemy")) 
        {
            //muestra al usuario que ha perdido el juego
           winText.text = "You Lose!";
           //reinicia el nivel
           StartCoroutine(RestartScene());
        }
    }

    void SetCountText ()
    {
        //texto a mostrar, con la puntuacion, que se ira actualizando conforme cambie la variable
        countText.text = "Count: " + count.ToString ();
        //si reune en total 12 o mas puntos...
        if (count >= 12)
        {
            //muestra al usuario que ha ganado la partida
            winText.text = "You Win!";
        }
    }

    IEnumerator RestartScene() 
    {
        //espera 1 segundo para que el jugador vea el mensaje
        yield return new WaitForSeconds(1);
        
        //reinicia el juego (la escena)
        SceneManager.LoadScene("Minigame");
    }
}