using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	void Start () {
		offset = transform.position - player.transform.position;
		
	}
	
	void LateUpdate () {

        //si el jugador se cae de la plataforma, la cámara le sigue hasta un punto, no toda la caída
        if(player.transform.position.y >= -5)
        {
            transform.position = player.transform.position + offset;
        }
		
	}
}
