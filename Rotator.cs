using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	void Update () {
		//añade una animacion a los cubos que hace que vayan rotando continuamente
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
