using UnityEngine;
using System.Collections;

public class NivelGanar : MonoBehaviour 
{
	float tiempoInicial;
	// Use this for initialization
	void Start () 
	{
		tiempoInicial = Time.time + 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time > tiempoInicial && Input.anyKey)
		{
			Application.LoadLevel(0);
		}
	}
}
