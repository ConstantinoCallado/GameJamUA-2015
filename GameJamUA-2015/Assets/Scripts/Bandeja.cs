using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bandeja : MonoBehaviour 
{
	public List<GameObject> listaSalchichas = new List<GameObject>();
	public GameObject prefabJugador;

	public static Bandeja bandejaRef;

	public void Awake()
	{

		bandejaRef = this;
	}
	
	public void Start()
	{
		Respawn();
	}

	public void Respawn()
	{
		GameManager.gameManagerRef.Restart();
		if(listaSalchichas.Count > 0)
		{
			GameObject.Instantiate(prefabJugador, listaSalchichas[listaSalchichas.Count-1].transform.position, Quaternion.identity); 
			Destroy(listaSalchichas[listaSalchichas.Count-1]);

			listaSalchichas.RemoveAt(listaSalchichas.Count-1);
		}
		else
		{
			Application.LoadLevel("NivelMorir");
		}
	}
}
