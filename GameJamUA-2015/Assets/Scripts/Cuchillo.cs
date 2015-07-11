using UnityEngine;
using System.Collections;

public class Cuchillo : MonoBehaviour 
{
	public void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Salchicha")
		{
			Salchicha.playerRef.Cortar();
		}
	}
}
