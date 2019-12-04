using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpinnerMover : MonoBehaviour {

    public float spinSpeed, direction;

	void Update () {
        //hace que las piezas giren a cierta velocidad y en un sentido
        transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed * direction);
	}
}
