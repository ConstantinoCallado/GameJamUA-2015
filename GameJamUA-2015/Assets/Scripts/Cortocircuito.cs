using UnityEngine;
using System.Collections;

public class Cortocircuito : MonoBehaviour {

    public void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Salchicha")
		{
			Salchicha.playerRef.Electrocutar();
		}
	}
}
