using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

    GameObject[] pauseObjects;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        HidePaused();
	}
	
	// Update is called once per frame
	void Update () {
		
        //boton P para pausar y reanudar el juego
        if(Input.GetKeyDown(KeyCode.P))
        {
            //si el juego esta en ejecucion...
            if(Time.timeScale == 1)
            {
                //pausa el juego
                Time.timeScale = 0;
                ShowPaused(); //muestra el menu de pausa
            } else if(Time.timeScale == 0) //si ya esta pausado...
            {
                //imprime en consola
                Debug.Log("High");
                //reanuda el juego
                Time.timeScale = 1;
                HidePaused(); //oculta el menu de pausa
            }
        }
	}

    //reinicia el nivel
    public void Reload()
    {
        SceneManager.LoadScene("Minigame");
    }

    //controla las pausas de la escena
    public void PauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        } else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    //muestra los objetos con la etiqueta ShowOnPause, es decir, el menu de pausa
    public void ShowPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //oculta los objetos con la etiqueta ShowOnPause
    public void HidePaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //carga el nivel indicado, en este caso lo usaremos para volver al menu principal (se asigna el nivel en la interfaz de Unity)
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

}
