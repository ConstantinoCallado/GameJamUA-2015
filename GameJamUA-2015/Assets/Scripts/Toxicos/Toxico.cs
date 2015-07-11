using UnityEngine;
using System.Collections;

public class Toxico : MonoBehaviour 
{
	public float toxicidad;
	public Collider collider;

	public void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Salchicha")
		{
			Salchicha.playerRef.toxicidadActual += toxicidad;
			Salchicha.playerRef.listaSucia.Add(this);
			Pegarse (other);
			Destroy(collider);
		}
	}

	public virtual void Pegarse(Collider other)
	{
		transform.parent = other.transform;
		//transform.localPosition = Vector3.zero;
	}
}
