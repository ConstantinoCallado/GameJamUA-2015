﻿using UnityEngine;
using System.Collections;

public class FireBehaviour : MonoBehaviour {

    private ParticleSystem[] fogones;

	// Use this for initialization
	void Awake () {

        fogones = GetComponentsInChildren<ParticleSystem>();
        StartCoroutine(Fogones());
	}
	

    IEnumerator Fogones()
    {
        int rnd = 0;
        int aux = 0;

        while(true)
        {
            aux = rnd;
            while(rnd == aux)
                rnd = Random.Range(0, fogones.Length-1);

            for(int i =0; i < fogones.Length; i++)
            {
                if (i == rnd)
                    fogones[i].Play();
                else fogones[i].Stop();
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
