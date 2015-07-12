﻿using UnityEngine;
using System.Collections;

public class Cable : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Salchicha")
        {
            Salchicha.playerRef.Electrocutar();
        }
    }
}
