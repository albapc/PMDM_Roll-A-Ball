using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpinnerMover : MonoBehaviour {

    public float spinSpeed, direction;

	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed * direction);
	}
}
