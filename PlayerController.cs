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
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

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
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }

        //HAY QUE SELECCIONAR IS TRIGGER EN ENEMY, SINO NO FUNCIONA
        if(other.gameObject.CompareTag ("Enemy")) 
        {
           winText.text = "You Lose!";
           StartCoroutine(RestartScene());
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
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