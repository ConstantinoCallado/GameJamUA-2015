using UnityEngine;
using System.Collections;

public class Fogones : MonoBehaviour {

    public ParticleSystem particle;

    public void OnTriggerEnter(Collider other)
    {
		Debug.Log("ADAS");
        if (other.transform.tag == "Salchicha" && particle.isPlaying)
        {
			Debug.Log("VASDAS");
            Salchicha.playerRef.Quemar();
        }
    }
}
