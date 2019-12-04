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
		player = GameObject.FindGameObjectWithTag("Player").transform;
		enemy = GetComponent<NavMeshAgent>();
		animator = player.GetComponent<Animator>();
	}

	void Update()
	{
		enemy.SetDestination(player.position);

		if(!enemy.pathPending && enemy.remainingDistance < proximidad) 
		{
			Debug.Log("Peligro");
			animator.SetBool("estarEnPeligro", true);

		} 
		else 
		{
			Debug.Log("Tranqui");
			animator.SetBool("estarEnPeligro", false);
		}
	}

	/* OTRA FORMA DE HACERLO
	
	public GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		if(!player){
         Debug.Log("Player sin tag!!");
     }

	}

	void Update()
	{
		GetComponent<NavMeshAgent>().destination = player.transform.position;
	}
	*/
}
