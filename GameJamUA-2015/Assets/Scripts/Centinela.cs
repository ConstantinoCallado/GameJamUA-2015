using UnityEngine;
using System.Collections;

public class Centinela : MonoBehaviour 
{
	public CinematicaChafar prefabCinematica;
	public static float cooldown;

    public void OnTriggerEnter(Collider other)
    {
		if (other.transform.tag == "Salchicha" && Time.time > cooldown)
        {
            if (other.GetComponent<Rigidbody>().velocity.sqrMagnitude >= 0.1f)
            {
				cooldown = Time.time + 7;
				StartCoroutine(corutinaCinematica());
                Debug.Log("PILLADA!!!!");
            }
        }
    }

	public IEnumerator corutinaCinematica()
	{
		Camera cameraOld = Camera.main;
		Salchicha.showUI = false;
		GameObject instanciado = GameObject.Instantiate(prefabCinematica.gameObject);
		instanciado.transform.position = new Vector3(900, 900, 900);
		instanciado.GetComponent<CinematicaChafar>().Show(3);
		SoundManager.soundManagerRef.audioAplastar.PlayDelayed(1);
		yield return new WaitForSeconds(3);

		Destroy(instanciado);
		Salchicha.playerRef.Kill();
	}
}
