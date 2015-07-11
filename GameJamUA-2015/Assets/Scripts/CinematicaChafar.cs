using UnityEngine;
using System.Collections;

public class CinematicaChafar : MonoBehaviour 
{
	public static CinematicaChafar cinematicaChafarRef;
	public Camera camaraCinematica;
	public Animation animationChef;

	public void Show(float segundos)
	{
		StartCoroutine(corutinaChafar(segundos));
	}

	public IEnumerator corutinaChafar(float segundos)
	{
		animationChef.Play();
		//Camera.SetupCurrent(camaraCinematica);

		yield return new WaitForSeconds(segundos);
	}
}
