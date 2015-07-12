using UnityEngine;
using System.Collections;

public class Limpieza : MonoBehaviour 
{
	float coolDown = 0;
	public float cantidad = 1;

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Salchicha")
		{
			if(Time.time > coolDown)
			{
				for(int i=0; i<cantidad; i++)
				{
					Salchicha.playerRef.RemoveRandomShit();
				}
				coolDown = Time.time + 2;
			}
		}
	}
}
