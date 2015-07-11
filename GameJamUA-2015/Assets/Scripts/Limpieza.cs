using UnityEngine;
using System.Collections;

public class Limpieza : MonoBehaviour 
{
	float coolDown = 0;

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Salchicha")
		{
			if(Time.time > coolDown)
			{
				Salchicha.playerRef.RemoveRandomShit();
				coolDown = Time.time + 2;
			}
		}
	}
}
