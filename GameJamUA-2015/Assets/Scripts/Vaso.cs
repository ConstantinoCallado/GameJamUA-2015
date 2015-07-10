using UnityEngine;
using System.Collections;

public class Vaso : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().centerOfMass += (Vector3.one * 0.109f);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
