using UnityEngine;
using System.Collections;

public class Plato : MonoBehaviour 
{
	public Collider collider;

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Salchicha")
		{
			collider.enabled = false;

			StartCoroutine(corutinaFinal());
		}
	}

	public IEnumerator corutinaFinal()
	{
		yield return new WaitForSeconds(1.5f);

		if(Salchicha.playerRef.toxicidadActual >= 100)
		{
			Debug.Log("Toxicidad alcanzada!");
		}
		else
		{
			Debug.Log("Toxicidad NO alcanzada!");
		}
        LevelManager.LoadLevel();
	}
}
