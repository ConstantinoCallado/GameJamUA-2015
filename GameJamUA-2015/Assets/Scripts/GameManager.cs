using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject prefabDeItems;

	public GameObject objetosInstanciados;

	public static GameManager gameManagerRef; 

	public void Awake()
	{
		gameManagerRef = this;
	}


	public void Restart()
	{
		if(objetosInstanciados != null)	Destroy(objetosInstanciados);
		objetosInstanciados = GameObject.Instantiate(prefabDeItems);
	}
}
