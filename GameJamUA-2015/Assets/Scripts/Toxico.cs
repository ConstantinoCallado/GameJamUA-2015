using UnityEngine;
using System.Collections;

public class Toxico : MonoBehaviour 
{
	public float toxicidad;

	public void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Salchicha")
		{
			//Salchicha.playerRef.toxicidadActual += toxicidad;
		}
	}
}
