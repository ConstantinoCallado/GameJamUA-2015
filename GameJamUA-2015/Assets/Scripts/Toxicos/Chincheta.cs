using UnityEngine;
using System.Collections;

public class Chincheta : Toxico 
{
	public override void Pegarse(Collider other)
	{
		SoundManager.soundManagerRef.audioCoger.Play();
		transform.forward = other.transform.position - transform.position;
		transform.parent = other.transform;
		//transform.localPosition = Vector3.zero;
	

	}
}
