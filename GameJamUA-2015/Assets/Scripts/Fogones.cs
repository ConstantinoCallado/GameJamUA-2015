using UnityEngine;
using System.Collections;

public class Fogones : MonoBehaviour {

    public ParticleSystem particle;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Salchicha" && particle.isPlaying)
        {
            Salchicha.playerRef.Quemar();
        }
    }
}
