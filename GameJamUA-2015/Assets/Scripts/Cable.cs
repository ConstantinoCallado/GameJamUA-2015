﻿using UnityEngine;
using System.Collections;

public class Cable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Salchicha")
        {
            Salchicha.playerRef.Electrocutar();
        }
    }
}
