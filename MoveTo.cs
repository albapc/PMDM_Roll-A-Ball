using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {
	Transform player;
	NavMeshAgent enemy;
	Animator animator;
	public float proximidad;

	void Awake()
	{
		//asignamos cada elemento con su objeto o componente
		player = GameObject.FindGameObjectWithTag("Player").transform;
		enemy = GetComponent<NavMeshAgent>();
		animator = player.GetComponent<Animator>();
	}

	void Update()
	{
		//asignamos la posicion del enemigo para que sea la misma que el jugador, es decir, que se dirija a el
		enemy.SetDestination(player.position);

		//si la distancia que hay entre el enemigo y el jugador es menor a la proximidad que indiquemos...
		if(!enemy.pathPending && enemy.remainingDistance < proximidad) 
		{
			//imprime en la consola lo siguiente:
			Debug.Log("Peligro");
			//el jugador cambia de color a rojo
			animator.SetBool("estarEnPeligro", true);

		} 
		else 
		{
			//imprime en la consola lo siguiente:
			Debug.Log("Tranqui");
			//el jugador cambia de color a verde
			animator.SetBool("estarEnPeligro", false);
		}
	}

	/* OTRA FORMA DE HACERLO
	
	//objeto de jugador
	public GameObject player;

	void Start () {
		//asignamos al objeto la etiqueta de "player"
		player = GameObject.FindGameObjectWithTag("Player");

		//si no lo encuentra...
		if(!player){
		//imprime lo siguiente:
         Debug.Log("Player sin tag!!");
     }

	}

	void Update()
	{
		//asigna la posicion del jugador al enemigo, es decir, que lo siga
		GetComponent<NavMeshAgent>().destination = player.transform.position;
	}
	*/
}
