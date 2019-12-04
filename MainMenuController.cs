using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void NewGame()
    {
        SceneManager.LoadScene("Minigame");
    }

    public void QuitGame()
    {
        //detiene el editor
        UnityEditor.EditorApplication.isPlaying = false;

        //detiene la aplicacion una vez compilada
        //Application.Quit();
    }
}
