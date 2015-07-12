using UnityEngine;
using System.Collections;

public class Plato : MonoBehaviour 
{
	public Collider collider;
	public GameObject gameObjectCocinero;


	public Transform anchorPointCocinero;


	public GameObject UIFelicidades;

	public MeshRenderer planoRenderer;

	public void Start()
	{
		gameObjectCocinero.SetActive(false);
		UIFelicidades.SetActive(false);
	}

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
		yield return new WaitForSeconds(0.5f);


		if(Salchicha.playerRef.toxicidadActual >= (LevelManager.GetToxicidad() * 0.65f))
		{
			gameObjectCocinero.SetActive(true);
			gameObjectCocinero.transform.parent = null;
			Salchicha.playerRef.showUI = false;
			Salchicha.playerRef.Freeze(transform);

			while((anchorPointCocinero.position - gameObjectCocinero.transform.position).magnitude > 0.1f)
			{
				gameObjectCocinero.transform.position += ((anchorPointCocinero.position - gameObjectCocinero.transform.position).normalized * 3 * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}

			yield return new WaitForSeconds(0.5f);

			transform.parent.parent = gameObjectCocinero.transform;

			float rotacionAcumulada = 0;
			float rotacionARealizar = 0;

			while(rotacionAcumulada < 180)
			{
				rotacionARealizar = 70 * Time.deltaTime;
				rotacionAcumulada += rotacionARealizar;
				gameObjectCocinero.transform.Rotate(new Vector3(0, -rotacionARealizar, 0));

				yield return new WaitForEndOfFrame();
			}

			UIFelicidades.SetActive(true);

			Debug.Log("Toxicidad alcanzada!");
		}
		else
		{
			Debug.Log("Toxicidad NO alcanzada!");
		}
   	}

	public void CerrarResultados()
	{
		StartCoroutine(fadeAndLoad());

	}

	public IEnumerator fadeAndLoad()
	{
		float tiempoFinal = Time.time + 1.3f;

		while(Time.time < tiempoFinal)
		{
			planoRenderer.material.color = new Color(planoRenderer.material.color.r, planoRenderer.material.color.g, planoRenderer.material.color.b, planoRenderer.material.color.a + (1 * Time.deltaTime));
			yield return new WaitForEndOfFrame();
		}

		LevelManager.LoadLevel();
	}
}
