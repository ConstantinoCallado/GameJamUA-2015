using UnityEngine;
using System.Collections;

public class Aceite : Toxico 
{
	public override void Pegarse(Collider other)
	{
		StartCoroutine(CorutinaReduccion());
		//Destroy(transform.parent.gameObject);
	}

	public IEnumerator CorutinaReduccion()
	{
		float tiempoFinal = Time.time + 2;

		while(Time.time < tiempoFinal)
		{
			transform.parent.localScale = transform.parent.localScale / 1.02f;
			yield return new WaitForEndOfFrame();
		}

		Destroy(transform.parent.gameObject);
	}
}
