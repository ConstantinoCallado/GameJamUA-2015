using UnityEngine;
using System.Collections;

public class Vaso : MonoBehaviour {

    private Vector3 initialCm;

	// Use this for initialization
	void Start () {
        initialCm = GetComponent<Rigidbody>().centerOfMass;
        GetComponent<Rigidbody>().centerOfMass += (Vector3.one * 0.108f);
	}
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(transform.rotation.x) > 80)
        {
            GetComponent<Rigidbody>().centerOfMass = initialCm;
            Debug.Log("SFFSDFSDFSD");
        }
	}
}
