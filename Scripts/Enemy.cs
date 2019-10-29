using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {


	// Use this for initialization
	public NavMeshAgent Enemigo;
	//nuestro enemigo la capsula
	public Transform goal;
	//nuestro player es publica
	public float proximidad;
	//distancia minima para camibar la animacion
	Animator animator;
	//Creamos el animator


	void Start () {
		Enemigo = GetComponent<NavMeshAgent>();
		Enemigo.destination = goal.position;
		//asignamos el animator del player
		animator = goal.GetComponent<Animator>();
		proximidad = 5;
	}

	void Update() {
		//actualizamos la posicion de la capsula con el goal
		//con el player/target
		Enemigo.destination = goal.position;
		//comparamos la distancia a la capsula y cambiamos la variable bool para forzar la transicion
		//de peligro a tranquilo.

		if (!Enemigo.pathPending && Enemigo.remainingDistance < proximidad)
		{
			Debug.Log("Peligro");
			//cambiamos la variable del animator
			animator.SetBool("IsCerca", true);
		}
		else
		{
			Debug.Log("Tranquilo");
			//cambiamos la variable del animator de nuevo para que cambie de transicion
			animator.SetBool("IsCerca", false);
		}
	}
	
}
