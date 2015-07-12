using UnityEngine;
using System.Collections;

public class MenuInicial : MonoBehaviour 
{
	public void Jugar()
	{
		Application.LoadLevel("Escena1");
	}

	public void Salir()
	{
		Application.Quit();
	}
}
