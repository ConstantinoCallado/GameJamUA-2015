using UnityEngine;
using System.Collections;

public class Centinela : MonoBehaviour {

    public float umbralDeteccion = 4f;

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
                if(other.GetComponent<Rigidbody>().velocity.sqrMagnitude >= umbralDeteccion)
                {
                    Debug.Log("PILLADA!!!!");
                }
        }
    }
}
